using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.ViewModel;
using KreditMotorService.Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _repo;
        public UserController(IUserService repo)
        {
            _repo = repo;

        }
        public IActionResult Index()
        {
            var model = new UserViewModel();
            model.listUser = _repo.getListUser();
            return View(model);
        }

        public IActionResult Edit(string Id)
        {
            var checkExist = _repo.getUser(Id);
            if (checkExist == null)
                RedirectToAction("Index");

            var model = new UserViewModel();
            model.getUser = checkExist;
            model.listRole = _repo.getListRoles();
            model.getUserRole =  _repo.getRole(model.getUser);
            
            
            return View(model);
        }
    }
}