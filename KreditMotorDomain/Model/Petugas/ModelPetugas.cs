using KreditMotorDomain.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KreditMotorDomain.Model.Petugas
{
    public class ModelPetugas
    {
        [Key]
        public int kd_petugas { get; set; }

        [StringLength(50)]
        public string nama { get; set; }

        [StringLength(50)]
        public string bagian { get; set; }

        [StringLength(100)]
        public string keterangan { get; set; }


        public ICollection<ApplicationUser> user { get; set; }
    }
}
