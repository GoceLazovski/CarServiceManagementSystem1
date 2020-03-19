using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Get(string userName);
    }
}
