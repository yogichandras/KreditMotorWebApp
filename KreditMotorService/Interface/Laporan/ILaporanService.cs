using KreditMotorDomain.Model.Pembayaran.Cicilan;
using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorService.Interface.Laporan
{
    public interface ILaporanService
    {
        List<ModelPembayaranCicilan> getLaporan(string no_kredit);
        List<ModelPembayaranCicilan> getLaporanHarian(DateTime tgl);
        List<ModelPembayaranCicilan> getLaporanBulan();
        List<ModelPembayaranCicilan> getLaporanDataBulan(int bln);
        List<ModelPembayaranCicilan> getLaporanTahun();
        List<ModelPembayaranCicilan> getLaporanDataTahun(int thn);
    }
}
