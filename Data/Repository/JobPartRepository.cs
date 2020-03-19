using Contracts.Interfaces;
using Contracts.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository
{
    public class JobPartRepository : GenericRepository<JobParts>, IJobPartRepository
    {
        internal ModelContext _context;
        internal DbSet<JobParts> _dbSet;

        public JobPartRepository(ModelContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<JobParts>();
        }

        public JobParts GetById(int jobId, int partId)
        {
            return dbSet
                .Include(i => i.SparePart)
                .Include(i => i.JobCard).SingleOrDefault(x => x.JobCardId == jobId && x.SparePartId == partId);
        }
    }
}
