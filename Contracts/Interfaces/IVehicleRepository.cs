using Contracts.Models;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> Get();
        IEnumerable<Vehicle> Get(int customerId);
        Vehicle GetById(int Id);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);
    }
}
