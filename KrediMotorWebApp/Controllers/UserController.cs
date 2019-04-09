using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.User;
using KreditMotorDomain.Model.User.ManageViewModels;
using KreditMotorDomain.Model.ViewModel;
using KreditMotorService.Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _repo;
        public UserController(IUserService repo)
        {
            _repo = repo;

        }

        #region Admin
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            ViewBag.nav = "admin";
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public JsonResult getAdmin()
        {
            var model = _repo.getListUserAdmin();
            return Json(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public JsonResult createAdmin([FromBody]CreateUserModel model)
        {
            model.Status = "admin";
            var result = _repo.addUser(model);
            return Json(result);
        }
        #endregion


        #region Kasir
        [Authorize(Roles = "admin,cso")]
        public IActionResult Kasir()
        {
            ViewBag.nav = "kasir";
            return View();
        }

        [Authorize(Roles = "admin,cso")]
        [HttpGet]
        public JsonResult getKasir()
        {
            var model = _repo.getListUserKasir();
            return Json(model);
        }

        [Authorize(Roles = "admin,cso")]
        [HttpPost]
        public JsonResult createKasir([FromBody]CreateUserModel model)
        {
            model.Status = "kasir";
            var result = _repo.addUser(model);
            return Json(result);
        }



        #endregion


        #region CSO
        [Authorize(Roles = "admin,cso")]
        public IActionResult Cso()
        {
            ViewBag.nav = "cso";
            return View();
        }

        [Authorize(Roles = "admin,cso")]
        [HttpGet]
        public JsonResult getCso()
        {
            var model = _repo.getListUserCso();
            return Json(model);
        }

        [Authorize(Roles = "admin,cso")]
        [HttpPost]
        public JsonResult createCso([FromBody]CreateUserModel model)
        {
            model.Status = "cso";
            var result = _repo.addUser(model);
            return Json(result);
        }
        #endregion


        #region Sales
        [Authorize(Roles = "admin,cso")]
        public IActionResult Sales()
        {
            ViewBag.nav = "sales";
            return View();
        }

        [Authorize(Roles = "admin,cso")]
        [HttpGet]
        public JsonResult getSales()
        {
            var model = _repo.getListUserSales();
            return Json(model);
        }

        [Authorize(Roles = "admin,cso")]
        [HttpPost]
        public JsonResult createSales([FromBody]CreateUserModel model)
        {
            model.Status = "sales";
            var result = _repo.addUser(model);
            return Json(result);
        }
        #endregion

        #region generic
        [Authorize(Roles = "admin,cso")]
        [HttpDelete]
        public JsonResult deleteUser(string id)
        {
            var result = _repo.deleteUser(id);
            return Json(result);
        }

        [Authorize(Roles = "admin,cso")]
        [HttpGet]
        public JsonResult editUser(string id)
        {
            var result = _repo.getEditUser(id);
            return Json(result);
        }

        [HttpPost]
        [Authorize(Roles = "admin,cso")]
        public JsonResult editDataUser([FromBody]CreateUserModel user)
        {
            var result = _repo.editUser(user);
            return Json(result);
        }

        #endregion

    }
}