using KreditMotorDomain.Model.Transaksi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KreditMotorDomain.Model.Pelanggan
{
   public class ModelPelanggan
    {
        [Key]
        public int kd_pelanggan { get; set; }

        [StringLength(50)]
        public string nama_pelanggan { get; set; }
        
        public int no_ktp { get; set; }

        [StringLength(100)]
        public string alamat { get; set; }

        [StringLength(50)]
        public string pekerjaan { get; set; }


        public ICollection<ModelTransaksiKredit> genKredit { get; set; }
    }

    public class EditPelanggan
    {
     
        public int edit_kd_pelanggan { get; set; }
        public string edit_nama_pelanggan { get; set; }
        public int edit_no_ktp { get; set; }
        public string edit_alamat { get; set; }
        public string edit_pekerjaan { get; set; }
    }
}
