using System.Collections.Generic;

namespace Contracts.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<JobCard> JobCards { get; set; }
    }
}
