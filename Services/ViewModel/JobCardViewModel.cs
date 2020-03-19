using Contracts.Models;
using Services.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.ViewModels
{
    public class JobCardViewModel
    {
        public JobCardViewModel()
        {

        }

        public JobCardViewModel(JobCard job)
        {
            Id = job.Id;
            Date = job.Date;
            OdometerReading = job.OdometerReading;
            Fuel = job.Fuel;
            DateIn = job.DateIn;
            DateOutEstimated = job.DateOutEstimated;
            DateOutActual = job.DateOutActual;
            CustomerComment = job.CustomerComment;
            JobDescription = job.JobDescription;
            Status = job.Status;
            EmployeeId = job.EmploeeId;
            VehicleId = job.VehicleId;
        }

        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Odometer Reading")]
        public string OdometerReading { get; set; }

        [Required]
        [Display(Name = "Fuel")]
        public Fuel Fuel { get; set; }

        [Display(Name = "Date In")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DateIn { get; set; }

        [Display(Name = "Date Out Estimated")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime DateOutEstimated { get; set; }

        [Display(Name = "Date Out Actual")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? DateOutActual { get; set; }

        [Display(Name = "Customer Coment")]
        public string CustomerComment { get; set; }

        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee")]
        public EmployeeViewModel Employee { get; set; }

        [Display(Name = "Vehicle Id")]
        public int VehicleId { get; set; }

        [Display(Name = "Vehicle")]
        public VehicleViewModel Vehicle { get; set; }

        [Display(Name = "Job Parts")]
        public ICollection<JobPartsViewModel> JobParts { get; set; }
    }
}
