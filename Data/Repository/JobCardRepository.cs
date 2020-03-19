using Contracts.Interfaces;
using Contracts.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class JobCardRepository : GenericRepository<JobCard>, IJobCardRepository
    {
        internal ModelContext _context;
        internal DbSet<JobCard> _dbSet;

        public JobCardRepository(ModelContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<JobCard>();
        }

        public IEnumerable<JobCard> Get(string searchString)
        {
            var job = from j in _context.JobCards select j;

            if (!string.IsNullOrEmpty(searchString))
            {
                job = job.Where(j => j.Vehicle.RegistrationNumber.Contains(searchString));
            }
            return job.ToList();
        }

        public override JobCard GetById(int Id)
        {
            JobCard job = _context.JobCards.Include(jc => jc.Employee).Include(jc => jc.JobParts).ThenInclude(s => s.SparePart).ToList().FirstOrDefault(jp => jp.Id == Id);
            return job;
        }
    }
}
