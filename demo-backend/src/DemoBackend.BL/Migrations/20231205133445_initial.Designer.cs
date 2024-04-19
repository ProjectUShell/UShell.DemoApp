﻿// <auto-generated />
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UShellDemo;

namespace Security.Migrations
{
    [DbContext(typeof(UShellDemoDbContext))]
    [Migration("20231205133445_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("UD")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UShellDemo.CarEntity", b =>
                {
                    b.Property<string>("LicPlateId")
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParkingLocationUid")
                        .HasColumnType("bigint");

                    b.Property<long>("TenantUid")
                        .HasColumnType("bigint");

                    b.HasKey("LicPlateId");

                    b.HasIndex("ParkingLocationUid");

                    b.HasIndex("TenantUid");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("UShellDemo.DriverEntity", b =>
                {
                    b.Property<string>("CarLicPlateId")
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<long>("PersonUid")
                        .HasColumnType("bigint")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<bool>("OwnsCarKeys")
                        .HasColumnType("bit");

                    b.HasKey("CarLicPlateId", "PersonUid");

                    b.HasIndex("PersonUid");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("UShellDemo.ParkingLocationEntity", b =>
                {
                    b.Property<long>("Uid")
                        .HasColumnType("bigint")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantUid")
                        .HasColumnType("bigint");

                    b.HasKey("Uid");

                    b.HasIndex("TenantUid");

                    b.ToTable("ParkingLocations");
                });

            modelBuilder.Entity("UShellDemo.PersonEntity", b =>
                {
                    b.Property<long>("Uid")
                        .HasColumnType("bigint")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TenantUid")
                        .HasColumnType("bigint");

                    b.HasKey("Uid");

                    b.HasIndex("TenantUid");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("UShellDemo.TenantEntity", b =>
                {
                    b.Property<long>("Uid")
                        .HasColumnType("bigint")
                        .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

                    b.HasKey("Uid");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("UShellDemo.CarEntity", b =>
                {
                    b.HasOne("UShellDemo.ParkingLocationEntity", "ParkingLocation")
                        .WithMany()
                        .HasForeignKey("ParkingLocationUid")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("UShellDemo.TenantEntity", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantUid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParkingLocation");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("UShellDemo.DriverEntity", b =>
                {
                    b.HasOne("UShellDemo.CarEntity", "Car")
                        .WithMany("Drivers")
                        .HasForeignKey("CarLicPlateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UShellDemo.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonUid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UShellDemo.ParkingLocationEntity", b =>
                {
                    b.HasOne("UShellDemo.TenantEntity", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantUid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("UShellDemo.PersonEntity", b =>
                {
                    b.HasOne("UShellDemo.TenantEntity", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantUid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("UShellDemo.CarEntity", b =>
                {
                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}