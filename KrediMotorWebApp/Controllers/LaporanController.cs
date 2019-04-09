using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorService.Interface.Laporan;
using KreditMotorService.Interface.Pembayaran;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    [Authorize]
    public class LaporanController : Controller
    {
        private readonly ILaporanService _repo;
        private readonly IPembayaranService _pembayaran;
        public LaporanController(ILaporanService repo, IPembayaranService pembayaran)
        {
            _repo = repo;
            _pembayaran = pembayaran;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Print(string no_kredit)
        {
            var model = _repo.getLaporan(no_kredit);
            var newModel = new PrintLaporan();
            newModel.laporan = model;
            return View(newModel);
        }

        [HttpPost]
        public IActionResult PrintSimulasi(string no_kredit)
        {
            var model = _repo.getLaporan(no_kredit);
            var newModel = new PrintLaporan();
            newModel.laporan = model;
            return View(newModel);
        }

        [HttpPost]
        public IActionResult PrintHarian(DateTime tgl)
        {
            var model = _repo.getLaporanHarian(tgl);
            var newModel = new PrintLaporan();
            if(model.Count == 0)
            {
                var tanggal = new ModelPembayaranCicilan();
                tanggal.tgl_bayar = tgl;
                model.Add(tanggal);
            }
            newModel.laporan = model;
            return View(newModel);
        }

        [HttpPost]
        public IActionResult PrintBulan(int bln)
        {
            var model = _repo.getLaporanDataBulan(bln);
            var newModel = new PrintLaporan();
            if (model.Count == 0)
            {
                var tanggal = new ModelPembayaranCicilan();
                tanggal.tgl_bayar.AddMonths(bln);
                model.Add(tanggal);
            }
            newModel.laporan = model;
            return View(newModel);
        }

        [HttpPost]
        public IActionResult PrintTahun(int thn)
        {
            var model = _repo.getLaporanDataTahun(thn);
            var newModel = new PrintLaporan();
            if (model.Count == 0)
            {
                var tanggal = new ModelPembayaranCicilan();
                tanggal.tgl_bayar.AddYears(thn);
                model.Add(tanggal);
            }
            newModel.laporan = model;
            return View(newModel);
        }

        public JsonResult getKreditList()
        {
            var model = _pembayaran.getKreditList();
            return Json(model);
        }

        public JsonResult getLaporanBulan()
        {
            var model = _repo.getLaporanBulan();
            return Json(model);
        }

        public JsonResult getLaporanTahun()
        {
            var model = _repo.getLaporanTahun();
            return Json(model);
        }
    }
}