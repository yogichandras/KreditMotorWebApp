using KreditMotorDomain.Model.Petugas;
using KreditMotorDomain.Model.User;
using KreditMotorEntityFrameworkCore;
using KreditMotorService.Interface.Laporan;
using KreditMotorService.Interface.Motor;
using KreditMotorService.Interface.Pelanggan;
using KreditMotorService.Interface.Pembayaran;
using KreditMotorService.Interface.Site;
using KreditMotorService.Interface.StoredProcedure;
using KreditMotorService.Interface.Transaksi;
using KreditMotorService.Interface.User;
using KreditMotorService.Service.Laporan;
using KreditMotorService.Service.Motor;
using KreditMotorService.Service.Pelanggan;
using KreditMotorService.Service.Pembayaran;
using KreditMotorService.Service.Site;
using KreditMotorService.Service.StoredProcedure;
using KreditMotorService.Service.Transaksi;
using KreditMotorService.Service.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KrediMotorWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("Default")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            //Password Strength Setting
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

                // User settings
                options.User.RequireUniqueEmail = false;
            });

            //Setting the Account Login page
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here,
                                                      // ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here,
                                                        // ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is
                                                                    // not set here, ASP.NET Core 
                                                                    // will default to 
                                                                    // /Account/AccessDenied
                options.SlidingExpiration = true;
            });


            // Add application services.
          
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IPelangganService,PelangganService>();
            services.AddScoped<IMotorService,MotorService>();
            services.AddScoped<ISiteService,SiteService>();
            services.AddScoped<ITransaksiService,TransaksiService>();
            services.AddScoped<IPembayaranService,PembayaranService>();
            services.AddScoped<ILaporanService,LaporanService>();
            services.AddScoped<IBookProcedureService,BookProcedureService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/Index");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{returnUrl?}");
            });

            CreateUserRoles(services).Wait();
        }


        public async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var PetugasManager = serviceProvider.GetRequiredService<DataContext>();

            //Adding Admin Role
            var roleCheck = PetugasManager.Roles.Where(x => x.Name.ToLower() == "admin" && x.Name.ToLower() == "cso" && x.Name.ToLower() == "kasir" && x.Name.ToLower() == "sales").ToList();
            if (roleCheck.Count == 0)
            {
                //create the roles and seed them to the database
               await RoleManager.CreateAsync(new IdentityRole("admin"));
               await RoleManager.CreateAsync(new IdentityRole("cso"));
               await RoleManager.CreateAsync(new IdentityRole("kasir"));
               await RoleManager.CreateAsync(new IdentityRole("sales"));
            }

            var userCheck = await PetugasManager.users.FirstOrDefaultAsync(x => x.UserName.ToLower() == "admin");
            if (userCheck == null)
            {
                var petugas = new ModelPetugas
                {
                    nama = "admin",
                    bagian = "admin",
                    keterangan = "admin"
                };
                var createPetugas = PetugasManager.petugas.Add(petugas);
                PetugasManager.SaveChanges();
                

                var User = new ApplicationUser
                {
                    UserName = "admin",
                    kd_petugas = petugas.kd_petugas
                };
                var password = "fsociety";
                var createUser = await UserManager.CreateAsync(User,password);
                if (createUser.Succeeded)
                {
                    userCheck = await PetugasManager.users.FirstOrDefaultAsync(x => x.UserName.ToLower() == "admin");
                }
            }
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            
            await UserManager.AddToRoleAsync(userCheck, "admin");
        }
    }
}
