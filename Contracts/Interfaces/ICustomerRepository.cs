using Contracts.Models;
using System.Collections.Generic;


namespace Contracts.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        IEnumerable<Customer> Get(string searchString);
        Customer GetById(int Id);
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);

    }
}