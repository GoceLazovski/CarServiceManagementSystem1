using Contracts.Interfaces;
using Contracts.Models;
using Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class VehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public VehicleService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<VehicleViewModel> GetVehicles(int customerId)
        {
            IEnumerable<Vehicle> vehicles = _unitOfWork.VehicleRepository.Get(customerId);

            if (vehicles == null)
            {
                return null;
            }

            List<VehicleViewModel> vehiclesView = new List<VehicleViewModel>();

            foreach (Vehicle vehicle in vehicles)
            {
                VehicleViewModel vehicleView = new VehicleViewModel(vehicle)
                    {
                        Owner = new CustomerViewModel(vehicle.Owner)
                    };
                vehiclesView.Add(vehicleView);
            }
            return vehiclesView;
        }

        public VehicleViewModel GetVehicle(int Id)
        {
            Vehicle vehicle = _unitOfWork.VehicleRepository.GetById(Id);

            if (vehicle == null)
            {
                return null;
            }

            VehicleViewModel vehicleView = new VehicleViewModel(vehicle)
            {
                Owner = new CustomerViewModel(vehicle.Owner),

                JobCards = vehicle.JobCards.Select(j => new JobCardViewModel(j)

                ).ToList(),

                OwnerName = vehicle.Owner.FirstName + " " + vehicle.Owner.LastName
            };
            return vehicleView;
        }

        public void InsertVehicle(VehicleViewModel vehiclePost)
        {
            Vehicle vehicle = new Vehicle
            {
                RegistrationNumber = vehiclePost.RegistrationNumber,
                CarModel = vehiclePost.CarModel,
                EngineNo = vehiclePost.EngineNo,
                ChassisNo = vehiclePost.ChassisNo,
                Year = vehiclePost.Year,
                GearSrNo = vehiclePost.GearSrNo,
                GearBoxSrNo = vehiclePost.GearBoxSrNo,
                TurboSrNo = vehiclePost.TurboSrNo,
                CustomerId = vehiclePost.CustomerId,
            };
            _unitOfWork.VehicleRepository.Insert(vehicle);
            _unitOfWork.Save();
            _logger.LogInfo($"Vehicle for client with Id {vehicle.Owner.Id} inserted");
        }

        public VehicleViewModel GetVehicleForUpdate(int Id)
        {
            Vehicle vehicle = _unitOfWork.VehicleRepository.GetById(Id);

            IEnumerable<Customer> customers = _unitOfWork.CustomerRepository.Get();
            List<CustomerViewModel> customersView = new List<CustomerViewModel>();
            foreach (Customer customer in customers)
            {
                CustomerViewModel customerView = new CustomerViewModel(customer);
                customersView.Add(customerView);
            }

            VehicleViewModel vehicleView = new VehicleViewModel(vehicle)
            {
                Customers = customersView
            };
            return vehicleView;
        }

        public void UpdateVehicle(VehicleViewModel vehiclePost)
        {
            Vehicle vehicle = _unitOfWork.VehicleRepository.GetById(vehiclePost.Id);

            vehicle.Id = vehiclePost.Id;
            vehicle.RegistrationNumber = vehiclePost.RegistrationNumber;
            vehicle.CarModel = vehiclePost.CarModel;
            vehicle.EngineNo = vehiclePost.EngineNo;
            vehicle.ChassisNo = vehiclePost.ChassisNo;
            vehicle.Year = vehiclePost.Year;
            vehicle.GearSrNo = vehiclePost.GearSrNo;
            vehicle.GearBoxSrNo = vehiclePost.GearBoxSrNo;
            vehicle.TurboSrNo = vehiclePost.TurboSrNo;
            vehicle.CustomerId = vehiclePost.CustomerId;

            _unitOfWork.VehicleRepository.Update(vehicle);
            _unitOfWork.Save();
            _logger.LogInfo($"Vehicle for client with Id {vehicle.Owner.Id} updated");
        }

        public void DeleteVehicle(VehicleViewModel vehiclePost)
        {
            Vehicle vehicle = _unitOfWork.VehicleRepository.GetById(vehiclePost.Id);

            vehicle.Id = vehiclePost.Id;
            vehicle.RegistrationNumber = vehiclePost.RegistrationNumber;
            vehicle.CarModel = vehiclePost.CarModel;
            vehicle.EngineNo = vehiclePost.EngineNo;
            vehicle.ChassisNo = vehiclePost.ChassisNo;
            vehicle.Year = vehiclePost.Year;
            vehicle.GearSrNo = vehiclePost.GearSrNo;
            vehicle.GearBoxSrNo = vehiclePost.GearBoxSrNo;
            vehicle.TurboSrNo = vehiclePost.TurboSrNo;
            vehicle.CustomerId = vehiclePost.CustomerId;

            _unitOfWork.VehicleRepository.Delete(vehicle);
            _unitOfWork.Save();
            _logger.LogInfo($"Vehicle with Id {vehicle.Id} deleted");
        }
    }
}
