using Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Services.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {

        }

        public CustomerViewModel(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            PhoneNumber = customer.PhoneNumber;
            Address = customer.Address;
        }

        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "First Name is needed.")]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z'\s]*$")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is needed.")]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"[a-zA-Z'\s]*$")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is needed.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Invalid Phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Vehicles")]
        public ICollection<VehicleViewModel> Vehicles { get; set; }
    }
}