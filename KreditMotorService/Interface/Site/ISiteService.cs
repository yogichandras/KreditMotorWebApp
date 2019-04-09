using KreditMotorDomain.Model.Setting;
using System;
using System.Collections.Generic;
using System.Text;

namespace KreditMotorService.Interface.Site
{
    public interface ISiteService
    {
        SiteSettingModel getSetting();
        SiteSettingModel editSetting(int id);
        bool editDataSetting(SiteSettingModel site);
    }
}
