using KreditMotorDomain.Model.Transaksi;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.StoredProcedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreditMotorService.Service.StoredProcedure
{
    public class BookProcedureService : IBookProcedureService
    {
        private readonly DataContext _context;

        public BookProcedureService(DataContext context)
        {
            _context = context;
        }

        public List<ModelTransaksiKredit> getTransaksiProcedure()
        {
           var model = _context.transaksi_kredit.FromSql("CALL `tampil_transaksi`()").ToList();
           return model;
        }
    }
}
