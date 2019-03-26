using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.ViewModel;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
   
    public class RoleController : Controller
    {
       
        private readonly DataContext _context;
        private readonly IUserService _repo;

        public RoleController( DataContext context, IUserService repo)
        {
           
            _context = context;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var model = new RoleViewModel
            {
                role = _repo.getListRoles()
            };

            return View(model);
        }
    }
}