using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IJobPartRepository
    {
        JobParts GetById(int jobId, int partId);
        void Insert(JobParts jobParts);
        void Update(JobParts jobParts);
    }
}
