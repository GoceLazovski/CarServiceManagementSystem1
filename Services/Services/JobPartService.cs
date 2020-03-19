using Contracts.Interfaces;
using Contracts.Models;
using Services.ViewModels;
using System.Collections.Generic;

namespace Services.Services
{
    public class JobPartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public JobPartService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public JobPartsViewModel InsertJobPartView(int jobId)
        {
            IEnumerable<SparePart> parts = _unitOfWork.SparePartsRepository.Get();
            List<SparePartsViewModel> partsView = new List<SparePartsViewModel>();
            foreach (SparePart part in parts)
            {
                SparePartsViewModel partView = new SparePartsViewModel(part);
                partsView.Add(partView);
            }

            JobParts jobParts = new JobParts();
            JobPartsViewModel jobPartsView = new JobPartsViewModel()
            {
                JobCardId = jobId,
                SparePartsList = partsView
            };
            return jobPartsView;
        }

        public void InsertJobPart(JobPartsViewModel jobPartView)
        {
            JobParts jobPart = new JobParts
            {
                JobCardId = jobPartView.JobCardId,
                SparePartId = jobPartView.SparePartId,
                QuantityInstalled = jobPartView.QuantityInstalled,
                SparePart = _unitOfWork.SparePartsRepository.GetById(jobPartView.SparePartId)
            };

            jobPart.SparePart.QuantityInStock = (jobPart.SparePart.QuantityInStock - jobPart.QuantityInstalled);

            _unitOfWork.JobPartRepository.Insert(jobPart);
            _unitOfWork.Save();
            _logger.LogInfo($"Part Id {jobPart.SparePartId} for job {jobPart.JobCardId} inserted");
        }

        public JobPartsViewModel GetJobPart(int jobId, int partId)
        {
            JobParts jobPart = _unitOfWork.JobPartRepository.GetById(jobId, partId);

            if (jobPart == null)
            {
                return null;
            }

            JobPartsViewModel jobPartsView = new JobPartsViewModel(jobPart)
            {
                JobCard = new JobCardViewModel(jobPart.JobCard),
                SparePart = new SparePartsViewModel(jobPart.SparePart)
            };

            return jobPartsView;
        }

        public void UpdateJobPart(JobPartsViewModel jobPartPost)
        {
            JobParts jobPart = _unitOfWork.JobPartRepository.GetById(jobPartPost.JobCardId, jobPartPost.SparePartId);

            int addedPart = jobPartPost.QuantityInstalled - jobPart.QuantityInstalled;
            
            jobPart.SparePart.QuantityInStock = (jobPart.SparePart.QuantityInStock - addedPart);
            
            jobPart.QuantityInstalled = jobPartPost.QuantityInstalled;

            _unitOfWork.JobPartRepository.Update(jobPart);
            _unitOfWork.Save();
            _logger.LogInfo($"Part Id {jobPart.SparePartId} for job {jobPart.JobCardId} updated");
        }
    }
}
