using Contracts.Interfaces;
using Contracts.Models;
using Services.ViewModel;

namespace Services.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public EmployeeService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public EmployeeViewModel GetEmployee(string userName)
        {
            Employee employee = _unitOfWork.EmployeeRepository.Get(userName);

            EmployeeViewModel employeeView = new EmployeeViewModel(employee);

             return employeeView;
        }
    }
}
