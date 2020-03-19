using Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Services.ViewModels
{
    public class VehicleViewModel
    {
        public VehicleViewModel()
        {
        }
        public VehicleViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            RegistrationNumber = vehicle.RegistrationNumber;
            CarModel = vehicle.CarModel;
            EngineNo = vehicle.EngineNo;
            ChassisNo = vehicle.ChassisNo;
            Year = vehicle.Year;
            GearSrNo = vehicle.GearSrNo;
            GearBoxSrNo = vehicle.GearBoxSrNo;
            TurboSrNo = vehicle.TurboSrNo;
            CustomerId = vehicle.CustomerId;
        }
       
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Registration Number is needed.")]
        [RegularExpression(@"^\(?([A-Z]{2})\)?[-. ]?([0-9]{3})[-. ]?([A-Z]{2})$", ErrorMessage = "Invalid Registration number")]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Engine Number")]
        public string EngineNo { get; set; }

        [Required]
        [Display(Name = "Chassis Number")]
        public string ChassisNo { get; set; }

        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [Display(Name = "Gear Serial Number")]
        public string GearSrNo { get; set; }

        [Required]
        [Display(Name = "Gear Box Serial Number")]
        public string GearBoxSrNo { get; set; }

        [Required]
        [Display(Name = "Turbo Serial Number")]
        public string TurboSrNo { get; set; }

        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }

        [Display(Name = "Owner")]
        public CustomerViewModel Owner { get; set; }

        [Display(Name = "Job Cards")]
        public ICollection<JobCardViewModel> JobCards { get; set; }

        [Display(Name = "Customers")]
        public List<CustomerViewModel> Customers { get; set; }

        [Display(Name = "Owner")]
        public string OwnerName { get; set; }
    }
}
