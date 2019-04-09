using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Laporan;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreditMotorService.Service.Laporan
{
    public class LaporanService : ILaporanService
    {
        private readonly DataContext _context;
        public LaporanService(DataContext context)
        {
            _context = context;
        }
        public List<ModelPembayaranCicilan> getLaporan(string no_kredit)
        {
            var model = _context.pembayaran_cicilan.AsNoTracking().Include(m => m.modelTransaksiKredit).Include(n => n.modelTransaksiKredit.modelPelanggan).Include(o => o.modelTransaksiKredit.modelMotor).Where(x => x.no_kredit == no_kredit).ToList();
            return model;
        }

        public List<ModelPembayaranCicilan> getLaporanHarian(DateTime tgl)
        {
            var model = _context.pembayaran_cicilan.Where(x => x.tgl_bayar.Date == tgl.Date).ToList();
            return model;
        }

        public List<ModelPembayaranCicilan> getLaporanBulan()
        {
            var model = _context.pembayaran_cicilan.GroupBy(x => x.tgl_bayar.ToString("MM/yyyy")).Select(bln => bln.First()).ToList();
            return model;
        }

        public List<ModelPembayaranCicilan> getLaporanDataBulan(int bln)
        {
            var model = _context.pembayaran_cicilan.Where(x => x.tgl_bayar.Month == bln).ToList();
            return model;
        }

        public List<ModelPembayaranCicilan> getLaporanTahun()
        {
            var model = _context.pembayaran_cicilan.GroupBy(x => x.tgl_bayar.Year).Select(bln => bln.First()).ToList();
            return model;
        }

        public List<ModelPembayaranCicilan> getLaporanDataTahun(int thn)
        {
            var model = _context.pembayaran_cicilan.Where(x => x.tgl_bayar.Year == thn).ToList();
            return model;
        }
    }
}
