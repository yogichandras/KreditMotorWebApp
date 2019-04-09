using KreditMotorDomain.Model.Transaksi;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Transaksi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreditMotorService.Service.Transaksi
{
    public class TransaksiService : ITransaksiService
    {
        private readonly DataContext _context;
        public TransaksiService(DataContext context)
        {
            _context = context;
        }

        public bool dontVerifTransaksi(string id)
        {
            try
            {
                var model = _context.transaksi_kredit.Find(id);
                model.status_verif = 0;
                model.tgl_verif = null;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ModelTransaksiKredit getDataTransaksi(string id)
        {
            var model = _context.transaksi_kredit.AsNoTracking().Include(x => x.modelPelanggan).Include(z => z.modelMotor).Include(u => u.users).Include(v => v.users.petugas).FirstOrDefault(y => y.no_kredit == id);
            return model;
        }

        public List<ModelTransaksiKredit> getTransaksi()
        {
            var model = _context.transaksi_kredit.AsNoTracking().Include(x => x.modelPelanggan).Include(z => z.modelMotor).ToList();
            return model;
        }

        public bool verifTransaksi(string id)
        {
            try
            {
                var model = _context.transaksi_kredit.Find(id);
                model.status_verif = 1;
                model.tgl_verif = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
