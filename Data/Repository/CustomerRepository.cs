using Contracts.Interfaces;
using Contracts.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        internal ModelContext _context;
        internal DbSet<Customer> _dbSet;

        public CustomerRepository(ModelContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Customer>();
        }

        public IEnumerable<Customer> Get(string searchString)
        {
            var customers = from c in _context.Customers select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.PhoneNumber.Contains(searchString));
            }
            return customers.ToList();
        }

        public override Customer GetById(int Id)
        {
            var customer = _context.Customers.Include(c => c.Vehicles).ToList().FirstOrDefault(v => v.Id == Id);
            return customer;
        }
    }
}
