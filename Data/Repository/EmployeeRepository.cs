using Contracts.Interfaces;
using Contracts.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        internal ModelContext _context;
        internal DbSet<Employee> _dbSet;

        public EmployeeRepository(ModelContext context) //: base(context)
        {
            _context = context;
            _dbSet = context.Set<Employee>();
        }

        public Employee Get(string userName)
        {
            Employee employee = _context.Employees.SingleOrDefault(e => e.UserName == userName);
            return employee;
        }
    }
}
