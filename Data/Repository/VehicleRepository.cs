using Contracts.Interfaces;
using Contracts.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        internal ModelContext _context;
        internal DbSet<Vehicle> _dbSet;

        public VehicleRepository(ModelContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Vehicle>();
        }

        public IEnumerable<Vehicle> Get(int customerId)
        {
            var vehicle = from v in _context.Vehicles select v;
            vehicle = vehicle.Where(v => v.CustomerId.Equals(customerId));

            return vehicle.ToList();
        }

        public override Vehicle GetById(int Id)
        {
            var vehicle = _context.Vehicles.Include(v => v.JobCards).ToList().FirstOrDefault(j => j.Id == Id);
            return vehicle;
        }
    }
}
