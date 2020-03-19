using Contracts.Interfaces;
using Data.Context;
using System;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContext context = new ModelContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ModelContext>());
        private ICustomerRepository customerRepository;
        private IVehicleRepository vehicleRepository;
        private IJobCardRepository jobCardRepository;
        private ISparePartsRepository sparePartsRepository;
        private IJobPartRepository jobPartRepository;
        private IEmployeeRepository employeeRepository;

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(context);
                }
                return customerRepository;
            }
        }

        public IVehicleRepository VehicleRepository
        {
            get
            {
                if (this.vehicleRepository == null)
                {
                    this.vehicleRepository = new VehicleRepository(context);
                }
                return vehicleRepository;
            }
        }

        public IJobCardRepository JobCardRepository
        {
            get
            {
                if (this.jobCardRepository == null)
                {
                    this.jobCardRepository = new JobCardRepository(context);
                }
                return jobCardRepository;
            }
        }

        public ISparePartsRepository SparePartsRepository
        {
            get
            {
                if (this.sparePartsRepository == null)
                {
                    this.sparePartsRepository = new SparePartsRepository(context);
                }
                return sparePartsRepository;
            }
        }

        public IJobPartRepository JobPartRepository
        {
            get
            {
                if (this.jobPartRepository == null)
                {
                    this.jobPartRepository = new JobPartRepository(context);
                }
                return jobPartRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if(this.employeeRepository == null)
                {
                    this.employeeRepository = new EmployeeRepository(context);
                }
                return employeeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
