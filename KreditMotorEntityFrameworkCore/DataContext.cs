using KreditMotorDomain.Model.Role;
using KreditMotorDomain.Model.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
