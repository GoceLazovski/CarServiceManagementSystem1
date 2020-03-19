using Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace Services.ViewModel
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {

        }
        public EmployeeViewModel(Employee employee)
        {
            Id = employee.Id;
            UserName = employee.UserName;
            Password = employee.Password;
        }

        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
