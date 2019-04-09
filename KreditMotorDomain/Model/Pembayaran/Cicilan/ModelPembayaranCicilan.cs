using KreditMotorDomain.Model.Transaksi;
using KreditMotorDomain.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KreditMotorDomain.Model.Pembayaran.Cicilan
{
    public class ModelPembayaranCicilan
    {
        [Key]
        [StringLength(10)]
        public string no_bayar { get; set; }

        [StringLength(10)]
        [ForeignKey("modelTransaksiKredit")]
        public string no_kredit { get; set; }
        public ModelTransaksiKredit modelTransaksiKredit { get; set; }

        public DateTime tgl_bayar { get; set; }
        public int bulan_bayar { get; set; }
        public int bulan_denda { get; set; }
        public int nominal_bayar { get; set; }
        public int sisa_cicilan { get; set; }
        public int denda { get; set; }
        public int status_bayar { get; set; }

        [StringLength(50)]
        [ForeignKey("users")]
        public string user_id { get; set; }
        public ApplicationUser users { get; set; }
    }

    public class ViewModelPembayaran
    {
        public int tgl { get; set; }
        public int bulan { get; set; }
        public int tahun { get; set; }
        public int cicilan { get; set; }
    }

    public class CreatePembayaran
    {
        public string no_kredit { get; set; }
        public int bulan_bayar { get; set; }
        public int denda { get; set; }
        public int bulan_denda { get; set; }
        public int nominal_bayar { get; set; }
    }

    public class PrintLaporan
    {
        public List<ModelPembayaranCicilan> laporan { get; set; }
    }
}
