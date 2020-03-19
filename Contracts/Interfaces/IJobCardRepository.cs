using Contracts.Models;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IJobCardRepository
    {
        IEnumerable<JobCard> Get();
        IEnumerable<JobCard> Get(string searchString);
        JobCard GetById(int Id);
        void Insert(JobCard customer);
        void Update(JobCard customer);
        void Delete(JobCard customer);
    }
}
