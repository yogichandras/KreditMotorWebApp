using KreditMotorDomain.Model.Motor;
using KreditMotorDomain.Model.Pagination;
using KreditMotorDomain.Model.Transaksi;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Motor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KreditMotorService.Service.Motor
{

    public class MotorService:IMotorService
    {
        private readonly DataContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public MotorService(DataContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> createMotor(ModelMotor motor, IFormFile picture)
        {


            if(picture != null) {
                var kd_motor = GetKode();
            string filename = ContentDispositionHeaderValue.Parse(picture.ContentDisposition).FileName.Trim('"');
            filename = EnsureFileName(filename);
            using (FileStream filestream = File.Create(Getpath(filename)))
            {
                    await picture.CopyToAsync(filestream);
                    using (var stream = new MemoryStream())
                    {
                        await picture.CopyToAsync(stream);
                        motor.picture = filename;
                        motor.kd_motor = kd_motor;
                        _context.motor.Add(motor);
                        _context.SaveChanges();
                    }
                  
                }
                return true;
            }
          
            else
            {
                return false;
            }
        }

        public PaginatedList<ModelMotor> getMotor(int? pageIndex,string search)
        {
            var model =  _context.motor.ToList();
            if(search != null)
            {
                search = search.ToLower();
                model = model.Where(x => x.merk.ToLower().Contains(search) || x.type.ToLower().Contains(search) || x.harga == int.Parse(search)).ToList();
            }

            int pageSize = 10;
            var paging = PaginatedList<ModelMotor>.Create(model,pageIndex ?? 1,pageSize);

            return paging;
        }

        private string Getpath(string filename)
        {
            //throw new NotImplementedException();
            string path = _hostingEnvironment.WebRootPath + "\\image_motor\\";
            if (!Directory.Exists(path))

                Directory.CreateDirectory(path);
            return path + filename;

        }

        private string EnsureFileName(string filename)
        {
            //throw new NotImplementedException();
            if (filename.Contains("\\"))

                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            return filename;
        }

        private string GetKode()
        {
            string codejadi;
            string codeString = "MTR";
            var getMaxCode = _context.motor.Max(m => m.kd_motor);
            if (getMaxCode != null)
            {
                var cek = getMaxCode.ToString().Length;
                var code = Convert.ToInt64(getMaxCode.ToString().Substring(getMaxCode.ToString().Length - 5, 5)) + 1;
                string joinstr = "00000" + code;
                codejadi = codeString + joinstr.Substring(joinstr.Length - 5, 5);
            }
            else
            {
                codejadi = codeString + "00001";
            }
            return codejadi;
        }

        public bool deleteMotor(string id)
        {
            var motor = _context.motor.Find(id);
            _context.motor.Remove(motor);
            _context.SaveChanges();
            return true;
        }

        public ModelMotor editMotor(string id)
        {
            var model = _context.motor.FirstOrDefault(m => m.kd_motor == id);
            return model;
        }

        public async Task<bool> editMotor(ModelMotor motor, IFormFile picture)
        {
            try {
                var model = _context.motor.FirstOrDefault(m => m.kd_motor == motor.kd_motor);

                if (picture != null)
            {
                
                string filename = ContentDispositionHeaderValue.Parse(picture.ContentDisposition).FileName.Trim('"');
                filename = EnsureFileName(filename);
                using (FileStream filestream = File.Create(Getpath(filename)))
                {
                    await picture.CopyToAsync(filestream);
                    using (var stream = new MemoryStream())
                    {
                        await picture.CopyToAsync(stream);
                            model.merk = motor.merk;
                            model.picture = filename;
                            model.harga = motor.harga;
                            model.type = motor.type;
                        _context.SaveChanges();
                    }

                }
                
            }

            else
            {
                    model.merk = motor.merk;
                    model.picture = motor.picture;
                    model.harga = motor.harga;
                    model.type = motor.type;
                    _context.SaveChanges();
                }
            return true;
            }
            catch
            {
                return false;
            }
        }

        public bool bookMotor(ViewModelMotor model)
        {
            try { 
            var motor = model.createMotor;
            var pelanggan = model.pelanggan;
            var kdBook = GetKodeBook();
            var book = new ModelTransaksiKredit();

            if (model.pelanggan.nama_pelanggan != null)
            {
                _context.pelanggan.Add(pelanggan);
                _context.SaveChanges();
            }
            book.no_kredit = kdBook;
            book.kd_motor = motor.kd_motor;
            book.kd_pelanggan = pelanggan.kd_pelanggan;
            book.tenor = model.tenor;
            book.bunga = model.bunga;
            book.cicilan = model.cicilan;
            book.dp = model.dp;
            book.user_id = model.userId;
            book.status_verif = 0;
         
            _context.transaksi_kredit.Add(book);
            _context.SaveChanges();
            return true;
            }
            catch
            {
                return false;
            }

        }

        private string GetKodeBook()
        {
            string codejadi;
            string codeString = "KRD";
            var getMaxCode = _context.transaksi_kredit.Max(m => m.no_kredit);
            if (getMaxCode != null)
            {
                var cek = getMaxCode.ToString().Length;
                var code = Convert.ToInt64(getMaxCode.ToString().Substring(getMaxCode.ToString().Length - 5, 5)) + 1;
                string joinstr = "00000" + code;
                codejadi = codeString + joinstr.Substring(joinstr.Length - 5, 5);
            }
            else
            {
                codejadi = codeString + "00001";
            }
            return codejadi;
        }




    }
}
