using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.Pelanggan;
using KreditMotorService.Interface.Pelanggan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    [Authorize(Roles = "admin,sales")]
    public class CustomerController : Controller
    {
        private readonly IPelangganService _repo;
        public CustomerController(IPelangganService repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            ViewBag.nav = "customer";
            return View();
        }

        
        [HttpGet]
        public JsonResult getCustomer()
        {
            var model = _repo.getListPelanggan();
            return Json(model);
        }
        
        [HttpPost]
        public JsonResult createDataCustomer([FromBody]ModelPelanggan model)
        {
            var result = _repo.createPelanggan(model);
            return Json(result);
        }

        [HttpGet]
        public JsonResult editCustomer(int id)
        {
            var result = _repo.getEditPelanggan(id);
            return Json(result);
        }

        //editDataCustomer

        [HttpPost]
        public JsonResult editDataCustomer([FromBody]EditPelanggan user)
        {
            var result = _repo.editPelanggan(user);
            return Json(result);
        }

        [HttpDelete]
        public JsonResult deleteCustomer(int id)
        {
            var result = _repo.deletePelanggan(id);
            return Json(result);
        }
    }
}