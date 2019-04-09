using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.Motor;
using KreditMotorDomain.Model.User;
using KreditMotorService.Interface.Motor;
using KreditMotorService.Interface.Site;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
   [Authorize(Roles = "admin,sales")]
    public class MotorController : Controller
    {
        private readonly IMotorService _repo;
        private readonly ISiteService _site;
        private readonly UserManager<ApplicationUser> _userManager;
        public MotorController(IMotorService repo, ISiteService site, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _site = site;
            _userManager = userManager;
        }

     
        
        
        public IActionResult Index(string returnUrl, int? pageIndex,string search)
        {
            ViewBag.nav = "motor";
            var model = new ViewModelMotor();
            model.pagingMotor = _repo.getMotor(pageIndex,search);
            if (returnUrl == "success")
                ViewBag.message = "success";
            else if (returnUrl == "success_insert")
                ViewBag.message = "success_insert";


            ViewBag.paging = pageIndex ?? 1;
            ViewBag.search = search;
            return View(model);
        }




        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewBag.nav = "motor";
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(ViewModelMotor motor,IFormFile picture)
        {
            if (ModelState.IsValid) {
                var result = await _repo.createMotor(motor.createMotor, picture);

                if (result)
                {
                    ViewBag.message = "success";
                    return RedirectToAction("Index", new { returnUrl = "success_insert"});
                }
                else
                {
                    ViewBag.message = "failed";
                    return View(motor);
                }
               
            }
            else
            {
                return View(motor);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult deleteMotor(string id)
        {
            var result = _repo.deleteMotor(id);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "admin")]
        public IActionResult Edit(string id)
        {
            ViewBag.nav = "motor";
            if (id == null)
              return RedirectToAction("Index");

            var model = _repo.editMotor(id);

            if(model == null)
              return  RedirectToAction("Index");

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(ModelMotor motor, IFormFile editPicture)
        {
            if (ModelState.IsValid)
            {
                var result = await _repo.editMotor(motor, editPicture);

                if (result)
                {
                    
                    return RedirectToAction("Index", new {returnUrl = "success" });
                }
                else
                {
                    ViewBag.message = "failed";
                    return View(motor);
                }
               
            }
            else
            {
                ViewBag.message = "failed";
                return View(motor);
            }
        }


        public IActionResult Book(string id)
        {
            ViewBag.nav = "motor";
            if (id == null)
                return RedirectToAction("Index");

            var model = _repo.editMotor(id);

            if (model == null)
                return RedirectToAction("Index");

            var site = _site.getSetting();

            var view = new ViewModelMotor();
            view.createMotor = model;
            view.site = site;
            

            return View(view);
        }

        [HttpPost]
        public IActionResult Book(ViewModelMotor motor)
        {
            motor.userId = _userManager.GetUserId(User);
            var result = _repo.bookMotor(motor);
            if (result)
            {
                return RedirectToAction("Verif");
            }
            else {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Verif()
        {
            ViewBag.nav = "motor";
            return View();
        }

        }
}