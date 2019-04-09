using KreditMotorDomain.Model.Transaksi;
using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorService.Interface.Transaksi
{
    public interface ITransaksiService
    {
        List<ModelTransaksiKredit> getTransaksi();
        ModelTransaksiKredit getDataTransaksi(string id);
        bool verifTransaksi(string id);
        bool dontVerifTransaksi(string id);
    }
}
