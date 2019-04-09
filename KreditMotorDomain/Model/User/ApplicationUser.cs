using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorDomain.Model.Petugas;
using KreditMotorDomain.Model.Transaksi;
using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KreditMotorDomain.Model.User
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser:IdentityUser
    {
        [ForeignKey("petugas")]
        public int kd_petugas { get; set; }
        public ModelPetugas petugas { get; set; }

        public ICollection<ModelPembayaranCicilan> genCicilan { get; set; }
        public ICollection<ModelTransaksiKredit> genKredit { get; set; }

    }
}
