using KreditMotorDomain.Model.Pagination;
using KreditMotorDomain.Model.Pelanggan;
using KreditMotorDomain.Model.Setting;
using KreditMotorDomain.Model.Transaksi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KreditMotorDomain.Model.Motor
{
    public class ModelMotor
    {
        [Key]
        [StringLength(10)]
        public string kd_motor { get; set; }

        [StringLength(20)]
        public string type { get; set; }

        [StringLength(30)]
        public string merk { get; set; }
        
        public int harga { get; set; }

        public string picture { get; set; }

        public ICollection<ModelTransaksiKredit> genKredit { get; set; }
    }

    public class ViewModelMotor
    {
        public List<ModelMotor> motor { get; set; }
        public PaginatedList<ModelMotor> pagingMotor { get; set; }
        public ModelMotor createMotor { get; set; }
        public SiteSettingModel site { get; set; }
        public ModelPelanggan pelanggan { get; set; }
        public int dp { get; set; }
        public int tenor { get; set; }
        public int bunga { get; set; }
        public int cicilan { get; set; }
        public string userId { get; set; }
    }
}
