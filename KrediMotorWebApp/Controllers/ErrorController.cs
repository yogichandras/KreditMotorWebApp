using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.nav = "denied";
            return View();
        }
    }
}