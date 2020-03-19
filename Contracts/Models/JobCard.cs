using System;
using System.Collections.Generic;

namespace Contracts.Models
{
    public class JobCard
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string OdometerReading { get; set; }
        public Fuel Fuel { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOutEstimated { get; set; }
        public DateTime? DateOutActual { get; set; }
        public string CustomerComment { get; set; }
        public string JobDescription { get; set; }
        public string Status { get; set; }

        public int EmploeeId { get; set; }
        public Employee Employee { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public ICollection<JobParts> JobParts { get; set; }
    }
}
