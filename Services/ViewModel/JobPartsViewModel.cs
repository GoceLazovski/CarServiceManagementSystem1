using Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.ViewModels
{
    public class JobPartsViewModel
    {
        public JobPartsViewModel()
        {
        }
        public JobPartsViewModel(JobParts jobParts)
        {
            JobCardId = jobParts.JobCardId;
            SparePartId = jobParts.SparePartId;
            QuantityInstalled = jobParts.QuantityInstalled;
        }

        [Display(Name = "Job Card Id")]
        public int JobCardId { get; set; }
        [Display(Name = "Job")]
        public JobCardViewModel JobCard { get; set; }

        
        [Display(Name = "Spare Part Id")]
        public int SparePartId { get; set; }
        [Display(Name = "Part")]
        public SparePartsViewModel SparePart { get; set; }

        public ICollection<SparePartsViewModel> SparePartsList { get; set; }

        [Required]
        [Range(0,4)]
        [Display(Name = "Quantity Installed")]
        public int QuantityInstalled { get; set; }
    }
}
