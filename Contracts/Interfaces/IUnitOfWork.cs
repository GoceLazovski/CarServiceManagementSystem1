using System;

namespace Contracts.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IJobCardRepository JobCardRepository { get; }
        ISparePartsRepository SparePartsRepository { get; }
        IJobPartRepository JobPartRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

        void Save();
    }
}
