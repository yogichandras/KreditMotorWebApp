using KreditMotorDomain.Model.Motor;
using KreditMotorDomain.Model.Pelanggan;
using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorDomain.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KreditMotorDomain.Model.Transaksi
{
   public class ModelTransaksiKredit
    {
        [Key]
        [StringLength(10)]
        public string no_kredit { get; set; }

        [StringLength(10)]
        [ForeignKey("modelMotor")]
        public string kd_motor { get; set; }
        public ModelMotor modelMotor { get; set; }

        [ForeignKey("modelPelanggan")]
        public int kd_pelanggan { get; set; }
        public ModelPelanggan modelPelanggan { get; set; }

        public int dp { get; set; }
        public int tenor { get; set; }
        public int bunga { get; set; }
        public int cicilan { get; set; }

        [StringLength(50)]
        [ForeignKey("users")]
        public string user_id { get; set; }
        public ApplicationUser users { get; set; }


        public int status_verif { get; set; }

        public DateTime? tgl_verif { get; set; }

        public ICollection<ModelPembayaranCicilan> genCicilan { get; set; }
    }

    public class ViewTransaksiModel
    {
        public List<ModelTransaksiKredit> transaksi { get; set; }
    }

    public class SuratPerjanjian
    {
        public ModelTransaksiKredit kredit { get; set; }
        public DateTime tgl { get; set; }
    }
}
