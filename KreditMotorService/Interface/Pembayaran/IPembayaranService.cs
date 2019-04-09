using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorDomain.Model.Transaksi;
using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorService.Interface.Pembayaran
{
    public interface IPembayaranService
    {
        List<ModelPembayaranCicilan> getPembayaran(string no_kredit);
        List<ModelTransaksiKredit> getKredit();
        List<ModelTransaksiKredit> getKreditList();
        string CreatePembayaran(CreatePembayaran pembayaran,string id);
        ModelPembayaranCicilan printPembayaran(string no_transaksi);
    }
}
