using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Context
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobCard> JobCards { get; set; }
        public DbSet<JobParts> JobParts { get; set; }
        public DbSet<SparePart> SparePart { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasMany(c => c.Vehicles).WithOne(v => v.Owner);

            modelBuilder.Entity<Vehicle>().HasOne(v => v.Owner).WithMany(c => c.Vehicles).HasForeignKey(v => v.CustomerId);
            modelBuilder.Entity<JobCard>().HasOne(jc => jc.Vehicle).WithMany(v => v.JobCards).HasForeignKey(jc => jc.VehicleId);
            modelBuilder.Entity<JobCard>().HasOne(jc => jc.Employee).WithMany(e => e.JobCards).HasForeignKey(jc => jc.EmploeeId);
            
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.LastName).HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).HasMaxLength(15);
            modelBuilder.Entity<Customer>().Property(c => c.Address).HasMaxLength(80);

            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Employee>().Property(e => e.UserName).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.UserName).HasMaxLength(20);
            modelBuilder.Entity<Employee>().Property(e => e.Password).IsRequired();
            modelBuilder.Entity<Employee>().Property(e => e.Password).HasMaxLength(20);

            modelBuilder.Entity<JobCard>().HasKey(jc => jc.Id);
            modelBuilder.Entity<JobCard>().Property(jc => jc.DateIn).IsRequired();
            modelBuilder.Entity<JobCard>().Property(jc => jc.DateOutEstimated).IsRequired();
            modelBuilder.Entity<JobCard>().Property(jc => jc.Fuel).IsRequired();
            modelBuilder.Entity<JobCard>().Property(jc => jc.Fuel).HasConversion(v => v.ToString(), v => (Fuel)Enum.Parse(typeof(Fuel), v));
            modelBuilder.Entity<JobCard>().Property(jc => jc.JobDescription).IsRequired();
            modelBuilder.Entity<JobCard>().Property(jc => jc.JobDescription).HasMaxLength(600);
            modelBuilder.Entity<JobCard>().Property(jc => jc.Status).IsRequired();

            modelBuilder.Entity<JobParts>().HasKey(jp => new { jp.JobCardId, jp.SparePartId });
            modelBuilder.Entity<JobParts>().Property(jp => jp.QuantityInstalled).IsRequired();
            modelBuilder.Entity<JobParts>().Property(jp => jp.QuantityInstalled).HasMaxLength(2);
            modelBuilder.Entity<JobParts>().HasOne(jp => jp.SparePart).WithMany(sp => sp.JobParts).HasForeignKey(jp => jp.SparePartId);
            modelBuilder.Entity<JobParts>().HasOne(jp => jp.JobCard).WithMany(jc => jc.JobParts).HasForeignKey(jp => jp.JobCardId);

            modelBuilder.Entity<SparePart>().HasKey(sp => sp.Id);
            modelBuilder.Entity<SparePart>().Property(sp => sp.ItemCode).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.ItemCode).HasMaxLength(30);
            modelBuilder.Entity<SparePart>().Property(sp => sp.Name).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.Name).HasMaxLength(30);
            modelBuilder.Entity<SparePart>().Property(sp => sp.ManufacturersCode).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.ManufacturersCode).HasMaxLength(30);
            modelBuilder.Entity<SparePart>().Property(sp => sp.ManufacturersName).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.ManufacturersName).HasMaxLength(30);
            modelBuilder.Entity<SparePart>().Property(sp => sp.QuantityInStock).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.QuantityInStock).HasMaxLength(3);
            modelBuilder.Entity<SparePart>().Property(sp => sp.Description).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.Description).HasMaxLength(200);
            modelBuilder.Entity<SparePart>().Property(sp => sp.Discount).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.Discount).HasMaxLength(2);
            modelBuilder.Entity<SparePart>().Property(sp => sp.UnitPricePurchase).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.UnitPricePurchase).HasMaxLength(5);
            modelBuilder.Entity<SparePart>().Property(sp => sp.UnitPriceSales).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.UnitPriceSales).HasMaxLength(5);
            modelBuilder.Entity<SparePart>().Property(sp => sp.VatRate).IsRequired();
            modelBuilder.Entity<SparePart>().Property(sp => sp.VatRate).HasMaxLength(2);

            modelBuilder.Entity<Vehicle>().HasKey(v => v.Id);
            modelBuilder.Entity<Vehicle>().Property(v => v.CarModel).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.CarModel).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.ChassisNo).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.ChassisNo).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.EngineNo).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.EngineNo).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.GearBoxSrNo).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.GearBoxSrNo).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.GearSrNo).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.GearSrNo).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.RegistrationNumber).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.RegistrationNumber).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.TurboSrNo).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.TurboSrNo).HasMaxLength(20);
            modelBuilder.Entity<Vehicle>().Property(v => v.Year).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(v => v.Year).HasMaxLength(4);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=GOCEL-L560\\SQLEXPRESS;Database=CarServiceManagementDataBase;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(builder);
        }
    }
}

