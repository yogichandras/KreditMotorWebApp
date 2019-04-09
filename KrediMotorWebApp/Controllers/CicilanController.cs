using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.Motor;
using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorDomain.Model.Transaksi;
using KreditMotorDomain.Model.User;
using KreditMotorService.Interface.Pembayaran;
using KreditMotorService.Interface.Site;
using KreditMotorService.Interface.Transaksi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    [Authorize(Roles ="kasir")]
    public class CicilanController : Controller
    {
        private readonly IPembayaranService _repo;
        private readonly ITransaksiService _repoTransaksi;
        private readonly UserManager<ApplicationUser> _user;
        private readonly ISiteService _site;
        public CicilanController(IPembayaranService repo, ITransaksiService repoTransaksi,UserManager<ApplicationUser> user, ISiteService site)
        {
            _repo = repo;
            _repoTransaksi = repoTransaksi;
            _user = user;
            _site = site;
        }
        public IActionResult Index(string returnUrl)
        {
            ViewBag.nav = "cicilan";
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.nav = "cicilan";
            var model = new ViewModelMotor();
            model.site = _site.getSetting();
            return View(model);
        }

        public JsonResult getKredit()
        {
            var model = _repo.getKredit();
            return Json(model);
        }
        public JsonResult getKreditList()
        {
            var model = _repo.getKreditList();
            return Json(model);
        }

        public JsonResult getDataKredit(string id)
        {
            var model = _repoTransaksi.getDataTransaksi(id);
            var newModel = new ViewModelPembayaran();
            var countModel = _repo.getPembayaran(id).Count();
            if(countModel==0)
            newModel.bulan = model.tgl_verif.GetValueOrDefault().Month;
            else
            {
                var newTgl = _repo.getPembayaran(id).First().bulan_denda;
                newModel.bulan = newTgl;
             }

            newModel.cicilan = model.cicilan;
            newModel.tgl = int.Parse(model.tgl_verif.GetValueOrDefault().ToString("dd"));
            newModel.tahun = int.Parse(model.tgl_verif.GetValueOrDefault().ToString("yyyy"));
            return Json(newModel);
        }

        public JsonResult getCicilanKe(string id)
        {
            var model = _repo.getPembayaran(id).Count;
            return Json(model);
        }

        [HttpPost]
        public IActionResult Create(CreatePembayaran model)
        {
            ViewBag.nav = "cicilan";
            var id = _user.GetUserId(User);
            var result = _repo.CreatePembayaran(model,id);

            if (result != "failed")
                return RedirectToAction("Print", "Cicilan", new { id = result });
            else
                return View(model);


        }

        public JsonResult getPembayaran(string id)
        {
            var model = _repo.getPembayaran(id);
            return Json(model);
        }

        public IActionResult Print(string id)
        {
            var model = _repo.printPembayaran(id);
            return View(model);
        }




    }
}