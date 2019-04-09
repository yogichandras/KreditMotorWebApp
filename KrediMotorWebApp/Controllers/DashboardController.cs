using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.ViewModel;
using KreditMotorService.Interface.StoredProcedure;
using KreditMotorService.Interface.Transaksi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ITransaksiService _repoTransaksi;
        private readonly IBookProcedureService _repoProcedure;
        public DashboardController(ITransaksiService repoTransaksi, IBookProcedureService repoProcedure)
        {
            _repoTransaksi = repoTransaksi;
            _repoProcedure = repoProcedure;
        }
        public IActionResult Index()
        {
            ViewBag.nav = "dashboard";
            var model = _repoTransaksi.getTransaksi();
            var view = new DashboardModel();
            view.book = _repoProcedure.getTransaksiProcedure();
            return View(view);
        }
    }
}