using KreditMotorDomain.Model.Transaksi;
using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorService.Interface.StoredProcedure
{
   public interface IBookProcedureService
    {
        List<ModelTransaksiKredit> getTransaksiProcedure();

    }
}
