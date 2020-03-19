using Contracts.Interfaces;
using Contracts.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class SparePartsRepository : GenericRepository<SparePart>, ISparePartsRepository
    {
        internal ModelContext _context;
        internal DbSet<SparePart> _dbSet;

        public SparePartsRepository(ModelContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<SparePart>();
        }

        public IEnumerable<SparePart> Get(string searchString)
        {
            var parts = from c in _context.SparePart select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                parts = parts.Where(s => s.Description.Contains(searchString));
            }
            return parts.ToList();
        }
    }
}
