using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.Transaksi;
using KreditMotorService.Interface.StoredProcedure;
using KreditMotorService.Interface.Transaksi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    [Authorize]
    public class TransaksiController : Controller
    {
        private readonly ITransaksiService _repo;
        private readonly IBookProcedureService _repoProcedure;
        public TransaksiController(ITransaksiService repo, IBookProcedureService repoProcedure)
        {
            _repo = repo;
            _repoProcedure = repoProcedure;
        }
        public IActionResult Book()
        {
            ViewBag.nav = "book";
            var model = _repo.getTransaksi();
            //var procedur = _repoProcedure.getTransaksiProcedure();
            var view = new ViewTransaksiModel();
            view.transaksi = model;
            return View(view);
        }

        [Authorize(Roles = "admin,cso,kasir")]
        [HttpPost]
        public IActionResult Verif(string no_kredit)
        {
            _repo.verifTransaksi(no_kredit);
            return RedirectToAction("Book");
        }

        [Authorize(Roles = "admin,cso,kasir")]
        [HttpPost]
        public IActionResult DontVerif(string no_kredit)
        {
            _repo.dontVerifTransaksi(no_kredit);
            return RedirectToAction("Book");
        }

        [Authorize(Roles = "admin,cso,kasir")]
        public IActionResult Perjanjian(string id)
        {
            var model = _repo.getDataTransaksi(id);
      
            return View(model);
        }
    }
}