using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorDomain.Model.Transaksi;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Pembayaran;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreditMotorService.Service.Pembayaran
{
    public class PembayaranService:IPembayaranService
    {
        private readonly DataContext _context;
        public PembayaranService(DataContext context)
        {
            _context = context;
        }

        public string CreatePembayaran(CreatePembayaran pembayaran,string id)
        {
            try { 
            var newPembayaran = new ModelPembayaranCicilan();
            newPembayaran.no_bayar = GetKode();
            newPembayaran.no_kredit = pembayaran.no_kredit;
            newPembayaran.bulan_bayar = pembayaran.bulan_bayar;
            newPembayaran.bulan_denda = pembayaran.bulan_denda;
            newPembayaran.denda = pembayaran.denda;
            newPembayaran.nominal_bayar = pembayaran.nominal_bayar;
            var getTenor = _context.transaksi_kredit.FirstOrDefault(m => m.no_kredit == newPembayaran.no_kredit);
            newPembayaran.sisa_cicilan = getTenor.tenor - pembayaran.bulan_bayar;
            newPembayaran.status_bayar = 1;
            newPembayaran.tgl_bayar = DateTime.Now;
            newPembayaran.user_id = id;
            _context.pembayaran_cicilan.Add(newPembayaran);
            _context.SaveChanges();
                return newPembayaran.no_bayar;
            }
            catch
            {
                return "failed";
            }
        }

        public List<ModelTransaksiKredit> getKredit()
        {
            var newModel = new List<ModelTransaksiKredit>();
            var model = _context.transaksi_kredit.Where(x => x.status_verif == 1).ToList();
            foreach (var item in model)
            {
                var tenor = item.tenor;
                var dataPembayaran = getPembayaran(item.no_kredit);
                if(dataPembayaran != null)
                {
                    var jumlah = dataPembayaran.Count;
                    var hasil = tenor - jumlah;
                    var bindData = new ModelTransaksiKredit();
                    bindData.bunga = item.bunga;
                    bindData.cicilan = item.cicilan;
                    bindData.dp = item.dp;
                    bindData.kd_motor = item.kd_motor;
                    bindData.kd_pelanggan = item.kd_pelanggan;
                    bindData.no_kredit = item.no_kredit;
                    bindData.status_verif = item.status_verif;
                    bindData.tenor = item.tenor;
                    bindData.tgl_verif = item.tgl_verif;
                    bindData.user_id = item.user_id;
                    if (hasil > 0)
                    {
                        newModel.Add(bindData);
                    }
                }
                else
                {
                    newModel.Add(item);
                }

            }

            return newModel;
        }

        public List<ModelTransaksiKredit> getKreditList()
        {
            var model = _context.transaksi_kredit.Where(x => x.status_verif == 1).ToList();
            return model;
        }

        public List<ModelPembayaranCicilan> getPembayaran(string no_kredit)
        {
            var model = _context.pembayaran_cicilan.Where(x => x.no_kredit == no_kredit).ToList();
            return model;
        }

        public ModelPembayaranCicilan printPembayaran(string no_transaksi)
        {
            var model = _context.pembayaran_cicilan.AsNoTracking().Include(x => x.modelTransaksiKredit).Include(z => z.modelTransaksiKredit.modelPelanggan).FirstOrDefault(y => y.no_bayar == no_transaksi);
            return model;
        }

        private string GetKode()
        {
            string codejadi;
            string codeString = "TRS";
            var getMaxCode = _context.pembayaran_cicilan.Max(m => m.no_bayar);
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
