﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20200302144439_AddEnumFuel")]
    partial class AddEnumFuel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contracts.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(80);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Contracts.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Contracts.Models.JobCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerComment");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateIn");

                    b.Property<DateTime?>("DateOutActual");

                    b.Property<DateTime>("DateOutEstimated");

                    b.Property<int>("EmploeeId");

                    b.Property<string>("Fuel")
                        .IsRequired();

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<string>("OdometerReading");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("EmploeeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("JobCards");
                });

            modelBuilder.Entity("Contracts.Models.JobParts", b =>
                {
                    b.Property<int>("JobCardId");

                    b.Property<int>("SparePartId");

                    b.Property<int>("QuantityInstalled")
                        .HasMaxLength(2);

                    b.HasKey("JobCardId", "SparePartId");

                    b.HasIndex("SparePartId");

                    b.ToTable("JobParts");
                });

            modelBuilder.Entity("Contracts.Models.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("Discount")
                        .HasMaxLength(2);

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LeadTimeDelivery");

                    b.Property<string>("ManufacturersCode")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("ManufacturersName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("QuantityInStock")
                        .HasMaxLength(3);

                    b.Property<float>("UnitPricePurchase")
                        .HasMaxLength(5);

                    b.Property<float>("UnitPriceSales")
                        .HasMaxLength(5);

                    b.Property<int>("VatRate")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("SparePart");
                });

            modelBuilder.Entity("Contracts.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ChassisNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("CustomerId");

                    b.Property<string>("EngineNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("GearBoxSrNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("GearSrNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("TurboSrNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Contracts.Models.JobCard", b =>
                {
                    b.HasOne("Contracts.Models.Employee", "Employee")
                        .WithMany("JobCards")
                        .HasForeignKey("EmploeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Contracts.Models.Vehicle", "Vehicle")
                        .WithMany("JobCards")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contracts.Models.JobParts", b =>
                {
                    b.HasOne("Contracts.Models.JobCard", "JobCard")
                        .WithMany("JobParts")
                        .HasForeignKey("JobCardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Contracts.Models.SparePart", "SparePart")
                        .WithMany("JobParts")
                        .HasForeignKey("SparePartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Contracts.Models.Vehicle", b =>
                {
                    b.HasOne("Contracts.Models.Customer", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
