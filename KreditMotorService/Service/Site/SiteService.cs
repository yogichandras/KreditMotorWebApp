using KreditMotorDomain.Model.Setting;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KreditMotorService.Service.Site
{
    public class SiteService:ISiteService
    {
        private readonly DataContext _context;
        public SiteService(DataContext context)
        {
            _context = context;
        }

        public bool editDataSetting(SiteSettingModel site)
        {
            try { 
            var model = editSetting(site.id_setting);
            model.dp_setting = site.dp_setting;
            model.surat_surat_setting = site.surat_surat_setting;
                model.bunga_setting = site.bunga_setting;
                model.denda_setting = site.denda_setting;
            _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            }


        public SiteSettingModel editSetting(int id)
        {
            var model = _context.site_setting.Find(id);
            return model;
        }

        public SiteSettingModel getSetting()
        {
            var model = _context.site_setting.First();
            return model;
        }
    }
}
