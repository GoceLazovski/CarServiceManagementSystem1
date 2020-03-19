using Contracts.Interfaces;
using Contracts.Models;
using Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public CustomerService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<CustomerViewModel> GetCustomers(string searchString)
        {
            IEnumerable<Customer> customers = _unitOfWork.CustomerRepository.Get(searchString);


            if (customers == null)
            {
                return null;
            }

            List<CustomerViewModel> customersView = new List<CustomerViewModel>();

            foreach (Customer customer in customers)
            {
                CustomerViewModel customerView = new CustomerViewModel(customer);
                
                customersView.Add(customerView);
            }

            return customersView;
        }

        public CustomerViewModel GetCustomer(int Id)
        {
            Customer customer = _unitOfWork.CustomerRepository.GetById(Id);

            if (customer == null)
            {
                return null;
            }

            CustomerViewModel customerView = new CustomerViewModel(customer)
            {
                Vehicles = customer.Vehicles.Select(v => new VehicleViewModel(v)).ToList()
            };

            return customerView;
        }

        public void InsertCustomer(CustomerViewModel customerPost)
        {
            Customer customer = new Customer
                {
                    FirstName = customerPost.FirstName,
                    LastName = customerPost.LastName,
                    PhoneNumber = customerPost.PhoneNumber,
                    Address = customerPost.Address
                };

            _unitOfWork.CustomerRepository.Insert(customer);
            _unitOfWork.Save();
            
            _logger.LogInfo($"Customer {customer.FirstName} {customer.LastName} with phone number {customer.PhoneNumber} inserted");
        }

        public void UpdateCustomer(CustomerViewModel customerPost)
        {
            Customer customer = _unitOfWork.CustomerRepository.GetById(customerPost.Id.Value);
            
            customer.Id = customerPost.Id.Value;
            customer.FirstName = customerPost.FirstName;
            customer.LastName = customerPost.LastName;
            customer.PhoneNumber = customerPost.PhoneNumber;
            customer.Address = customerPost.Address;

            _unitOfWork.CustomerRepository.Update(customer);
            _unitOfWork.Save();
            _logger.LogInfo($"Customer {customer.FirstName} {customer.LastName} with phone number {customer.PhoneNumber} updated");
        }

        public void DeleteCustomer(CustomerViewModel customerPost)
        {
            Customer customer = _unitOfWork.CustomerRepository.GetById(customerPost.Id.Value);
            
            customer.Id = customerPost.Id.Value;
            customer.FirstName = customerPost.FirstName;
            customer.LastName = customerPost.LastName;
            customer.PhoneNumber = customerPost.PhoneNumber;
            customer.Address = customerPost.Address;

            _unitOfWork.CustomerRepository.Delete(customer);
            _unitOfWork.Save();
            _logger.LogInfo($"Customer {customer.FirstName} {customer.LastName} with phone number {customer.PhoneNumber} deleted");
        }
    }
}
