using KreditMotorDomain.Model.Motor;
using KreditMotorDomain.Model.Pelanggan;
using KreditMotorDomain.Model.Pembayaran.Cicilan;
using KreditMotorDomain.Model.Petugas;
using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.Setting;
using KreditMotorDomain.Model.Transaksi;
using KreditMotorDomain.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KreditMotorEntityFrameworkCore
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> users { get; set; }
        public virtual DbSet<RoleModel> roles { get; set; }
        public virtual DbSet<ModelPelanggan> pelanggan { get; set; }
        public virtual DbSet<ModelPetugas> petugas { get; set; }
        public virtual DbSet<ModelMotor> motor { get; set; }
        public virtual DbSet<ModelTransaksiKredit> transaksi_kredit { get; set; }
        public virtual DbSet<ModelPembayaranCicilan> pembayaran_cicilan { get; set; }
        public virtual DbSet<SiteSettingModel> site_setting { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var table = entityType.Relational().TableName;
                if (table.StartsWith("AspNet"))
                {
                    entityType.Relational().TableName = table.Substring(6);
                }

                
            };

            builder.Entity<IdentityUser>(b =>
            {
                var normalizedEmailIndex = b.HasIndex(u => new { u.NormalizedEmail }).Metadata;
                b.Metadata.RemoveIndex(normalizedEmailIndex.Properties);
               


                b.ToTable("user");
                b.Ignore("PhoneNumber");
                b.Ignore("PhoneNumberConfirmed");
                b.Ignore("Email");
                b.Ignore("NormalizedEmail");
                b.Ignore("EmailConfirmed");
                b.Ignore("LockoutEnd");
                b.Ignore("LockoutEnabled");
                b.Ignore("AccessFailedCount");
             
                
              
            });

            

        }
    }
}
