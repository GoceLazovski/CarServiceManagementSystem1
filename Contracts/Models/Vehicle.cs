using System.Collections.Generic;

namespace Contracts.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string CarModel { get; set; }
        public string EngineNo { get; set; }
        public string ChassisNo { get; set; }
        public string Year { get; set; }
        public string GearSrNo { get; set; }
        public string GearBoxSrNo { get; set; }
        public string TurboSrNo { get; set; }

        public int CustomerId { get; set; }

        public Customer Owner { get; set; }
        public ICollection<JobCard> JobCards { get; set; }
    }
}
