using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KreditMotorDomain.Model.Setting;
using KreditMotorService.Interface.Site;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrediMotorWebApp.Controllers
{
  
    [Authorize]
    public class SiteController : Controller
    {
        private readonly ISiteService _repo;
        public SiteController(ISiteService repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getSite()
        {
            var model = _repo.getSetting();
            return Json(model);
        }

        [HttpPost]
        public JsonResult editDataSite([FromBody]SiteSettingModel site)
        {
            var model = _repo.editDataSetting(site);
            return Json(model);
        }
    }
}