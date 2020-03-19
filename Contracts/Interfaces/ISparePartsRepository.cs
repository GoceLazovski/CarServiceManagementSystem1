using Contracts.Models;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface ISparePartsRepository
    {
        IEnumerable<SparePart> Get();
        IEnumerable<SparePart> Get(string searchString);
        SparePart GetById(int Id);
        void Insert(SparePart sparePart);
        void Update(SparePart sparePart);
        void Delete(SparePart sparePart);
    }
}
