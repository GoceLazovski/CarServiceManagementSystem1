using Contracts.Interfaces;
using Contracts.Models;
using Services.ViewModels;
using System.Collections.Generic;
using Services.ViewModel;

namespace Services.Services
{
    public class JobCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public JobCardService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<JobCardViewModel> GetJobCard(string searchString)
        {
            IEnumerable<JobCard> jobCards = _unitOfWork.JobCardRepository.Get(searchString);

            if (jobCards == null)
            {
                return null;
            }

            List<JobCardViewModel> jobCardsView = new List<JobCardViewModel>();

            foreach (JobCard jobCard in jobCards)
            {
                JobCardViewModel jobCardView = new JobCardViewModel(jobCard);

                jobCardsView.Add(jobCardView);
            }

            return jobCardsView;
        }

        public JobCardViewModel GetJobCard(int Id)
        {
            JobCard jobCard = _unitOfWork.JobCardRepository.GetById(Id);

            if (jobCard == null)
            {
                return null;
            }
            List<JobPartsViewModel> jobPartsViews = new List<JobPartsViewModel>();
            
            foreach (JobParts jobPart in jobCard.JobParts)
            {
                JobPartsViewModel jobPartView = new JobPartsViewModel(jobPart)
                {
                    SparePart = new SparePartsViewModel(jobPart.SparePart)
                };
                jobPartsViews.Add(jobPartView);
            }

            EmployeeViewModel employee = new EmployeeViewModel(jobCard.Employee);

            JobCardViewModel jobCardView = new JobCardViewModel(jobCard)
            {
                JobParts = jobPartsViews,
                Employee = employee
            };

            return jobCardView;
        }

        public void InsertjobCard(JobCardViewModel jobCardPost)
        {
            JobCard jobCard = new JobCard
            {
                Date = jobCardPost.Date,
                OdometerReading = jobCardPost.OdometerReading,
                Fuel = jobCardPost.Fuel,
                DateIn = jobCardPost.DateIn,
                DateOutEstimated = jobCardPost.DateOutEstimated,
                DateOutActual = jobCardPost.DateOutActual,
                CustomerComment = jobCardPost.CustomerComment,
                JobDescription = jobCardPost.JobDescription,
                Status = jobCardPost.Status,
                EmploeeId = jobCardPost.EmployeeId,

                VehicleId = jobCardPost.VehicleId
            };

            _unitOfWork.JobCardRepository.Insert(jobCard);
            _unitOfWork.Save();
            _logger.LogInfo($"JobCard for vehicle Id {jobCard.VehicleId} inserted");

        }

        public void UpdateJobCard(JobCardViewModel jobCardPost)
        {
            JobCard jobCard = _unitOfWork.JobCardRepository.GetById(jobCardPost.Id.Value);

            jobCard.Date = jobCardPost.Date;
            jobCard.OdometerReading = jobCardPost.OdometerReading;
            jobCard.Fuel = jobCardPost.Fuel;
            jobCard.DateIn = jobCardPost.DateIn;
            jobCard.DateOutEstimated = jobCardPost.DateOutEstimated;
            jobCard.DateOutActual = jobCardPost.DateOutActual;
            jobCard.CustomerComment = jobCardPost.CustomerComment;
            jobCard.JobDescription = jobCardPost.JobDescription;
            jobCard.Status = jobCardPost.Status;
            jobCard.EmploeeId = jobCardPost.EmployeeId;
            jobCard.VehicleId = jobCardPost.VehicleId;

            _unitOfWork.JobCardRepository.Update(jobCard);
            _unitOfWork.Save();
            _logger.LogInfo($"JobCard for vehicle Id {jobCard.VehicleId} updated");
        }

        public void DeleteJobCard(JobCardViewModel jobCardPost)
        {
            JobCard jobCard = _unitOfWork.JobCardRepository.GetById(jobCardPost.Id.Value);
            
            jobCard.Date = jobCardPost.Date;
            jobCard.OdometerReading = jobCardPost.OdometerReading;
            jobCard.Fuel = jobCardPost.Fuel;
            jobCard.DateIn = jobCardPost.DateIn;
            jobCard.DateOutEstimated = jobCardPost.DateOutEstimated;
            jobCard.DateOutActual = jobCardPost.DateOutActual;
            jobCard.CustomerComment = jobCardPost.CustomerComment;
            jobCard.JobDescription = jobCardPost.JobDescription;
            jobCard.Status = jobCardPost.Status;
            jobCard.EmploeeId = jobCardPost.EmployeeId;
            jobCard.VehicleId = jobCardPost.VehicleId;

            _unitOfWork.JobCardRepository.Delete(jobCard);
            _unitOfWork.Save();
            _logger.LogInfo($"JobCard for vehicle Id {jobCard.VehicleId} deleted");
        }
    }
}
