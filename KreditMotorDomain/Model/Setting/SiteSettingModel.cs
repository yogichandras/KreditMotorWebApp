using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KreditMotorDomain.Model.Setting
{
    public class SiteSettingModel
    {
        [Key]
        public int id_setting { get; set; }

        public float dp_setting { get; set; }
        public float bunga_setting { get; set; }
        public float denda_setting { get; set; }

        public float surat_surat_setting { get; set; }
    }
}
