﻿// <auto-generated />
using System;
using KreditMotorEntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KreditMotorEntityFrameworkCore.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20190401144816_remove unnecessary field")]
    partial class removeunnecessaryfield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KreditMotorDomain.Model.Motor.ModelMotor", b =>
                {
                    b.Property<string>("kd_motor")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("harga");

                    b.Property<string>("merk")
                        .HasMaxLength(30);

                    b.Property<string>("type")
                        .HasMaxLength(20);

                    b.HasKey("kd_motor");

                    b.ToTable("motor");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Pelanggan.ModelPelanggan", b =>
                {
                    b.Property<int>("kd_pelanggan")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("alamat")
                        .HasMaxLength(100);

                    b.Property<string>("nama_pelanggan")
                        .HasMaxLength(50);

                    b.Property<int>("no_ktp");

                    b.Property<string>("pekerjaan")
                        .HasMaxLength(50);

                    b.HasKey("kd_pelanggan");

                    b.ToTable("pelanggan");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Pembayaran.Cicilan.ModelPembayaranCicilan", b =>
                {
                    b.Property<string>("no_bayar")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("bulan_bayar");

                    b.Property<int>("denda");

                    b.Property<string>("no_kredit")
                        .HasMaxLength(10);

                    b.Property<int>("nominal_bayar");

                    b.Property<int>("sisa_cicilan");

                    b.Property<int>("status_bayar");

                    b.Property<DateTime>("tgl_bayar");

                    b.Property<string>("user_id")
                        .HasMaxLength(50);

                    b.HasKey("no_bayar");

                    b.HasIndex("no_kredit");

                    b.HasIndex("user_id");

                    b.ToTable("pembayaran_cicilan");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Petugas.ModelPetugas", b =>
                {
                    b.Property<int>("kd_petugas")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bagian")
                        .HasMaxLength(50);

                    b.Property<string>("keterangan")
                        .HasMaxLength(100);

                    b.Property<string>("nama")
                        .HasMaxLength(50);

                    b.HasKey("kd_petugas");

                    b.ToTable("petugas");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Transaksi.ModelTransaksiKredit", b =>
                {
                    b.Property<string>("no_kredit")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10);

                    b.Property<int>("bunga");

                    b.Property<int>("cicilan");

                    b.Property<int>("dp");

                    b.Property<string>("kd_motor")
                        .HasMaxLength(10);

                    b.Property<int>("kd_pelanggan");

                    b.Property<int>("status_verif");

                    b.Property<int>("tenor");

                    b.Property<DateTime>("tgl_verif");

                    b.Property<string>("user_id")
                        .HasMaxLength(50);

                    b.HasKey("no_kredit");

                    b.HasIndex("kd_motor");

                    b.HasIndex("kd_pelanggan");

                    b.HasIndex("user_id");

                    b.ToTable("transaksi_kredit");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Role.RoleModel", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");


                    b.ToTable("Roles");

                    b.HasDiscriminator().HasValue("RoleModel");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.User.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("kd_petugas");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("kd_petugas");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Pembayaran.Cicilan.ModelPembayaranCicilan", b =>
                {
                    b.HasOne("KreditMotorDomain.Model.Transaksi.ModelTransaksiKredit", "modelTransaksiKredit")
                        .WithMany("genCicilan")
                        .HasForeignKey("no_kredit");

                    b.HasOne("KreditMotorDomain.Model.User.ApplicationUser", "users")
                        .WithMany("genCicilan")
                        .HasForeignKey("user_id");
                });

            modelBuilder.Entity("KreditMotorDomain.Model.Transaksi.ModelTransaksiKredit", b =>
                {
                    b.HasOne("KreditMotorDomain.Model.Motor.ModelMotor", "modelMotor")
                        .WithMany("genKredit")
                        .HasForeignKey("kd_motor");

                    b.HasOne("KreditMotorDomain.Model.Pelanggan.ModelPelanggan", "modelPelanggan")
                        .WithMany("genKredit")
                        .HasForeignKey("kd_pelanggan")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KreditMotorDomain.Model.User.ApplicationUser", "users")
                        .WithMany("genKredit")
                        .HasForeignKey("user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KreditMotorDomain.Model.User.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KreditMotorDomain.Model.User.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KreditMotorDomain.Model.User.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KreditMotorDomain.Model.User.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KreditMotorDomain.Model.User.ApplicationUser", b =>
                {
                    b.HasOne("KreditMotorDomain.Model.Petugas.ModelPetugas", "petugas")
                        .WithMany("user")
                        .HasForeignKey("kd_petugas")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
