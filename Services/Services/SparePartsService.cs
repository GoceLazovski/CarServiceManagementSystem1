using Contracts.Interfaces;
using Contracts.Models;
using Services.ViewModels;
using System.Collections.Generic;

namespace Services.Services
{
    public class SparePartsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public SparePartsService(IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<SparePartsViewModel> GetParts(string searchString)
        {
            IEnumerable<SparePart> parts = _unitOfWork.SparePartsRepository.Get(searchString);

            if (parts == null)
            {
                return null;
            }

            List<SparePartsViewModel> partsView = new List<SparePartsViewModel>();

            foreach (SparePart part in parts)
            {
                SparePartsViewModel partView = new SparePartsViewModel(part);
                partsView.Add(partView);
            }
            return partsView;
        }

        public SparePartsViewModel GetPart(int Id)
        {
            SparePart part = _unitOfWork.SparePartsRepository.GetById(Id);

            SparePartsViewModel partView = new SparePartsViewModel(part);
            
            return partView;
        }

        public void InsertPart(SparePartsViewModel partPost)
        {
            SparePart part = new SparePart
                {
                    ItemCode = partPost.ItemCode,
                    Name = partPost.Name,
                    Description = partPost.Description,
                    QuantityInStock = partPost.QuantityInStock,
                    ManufacturersCode = partPost.ManufacturersCode,
                    ManufacturersName = partPost.ManufacturersName,
                    LeadTimeDelivery = partPost.LeadTimeDelivery,
                    UnitPricePurchase = partPost.UnitPricePurchase,
                    UnitPriceSales = partPost.UnitPriceSales,
                    Discount = partPost.Discount,
                    VatRate = partPost.VatRate,
                    SparePartImage = partPost.SparePartImage
                };

            _unitOfWork.SparePartsRepository.Insert(part);
            _unitOfWork.Save();
            _logger.LogInfo($"Part Id {partPost.Id} inserted");
        }

        public void UpdatePart(SparePartsViewModel partPost)
        {
            SparePart part = _unitOfWork.SparePartsRepository.GetById(partPost.Id);

            part.ItemCode = partPost.ItemCode;
            part.Name = partPost.Name;
            part.Description = partPost.Description;
            part.QuantityInStock = partPost.QuantityInStock;
            part.ManufacturersCode = partPost.ManufacturersCode;
            part.ManufacturersName = partPost.ManufacturersName;
            part.LeadTimeDelivery = partPost.LeadTimeDelivery;
            part.UnitPricePurchase = partPost.UnitPricePurchase;
            part.UnitPriceSales = partPost.UnitPriceSales;
            part.Discount = partPost.Discount;
            part.VatRate = partPost.VatRate;
            part.SparePartImage = partPost.SparePartImage;

            _unitOfWork.SparePartsRepository.Update(part);
            _unitOfWork.Save();
            _logger.LogInfo($"Part Id {partPost.Id} Updated");
        }

        public void DeletePart(SparePartsViewModel partPost)
        {
            SparePart part = _unitOfWork.SparePartsRepository.GetById(partPost.Id);

            part.ItemCode = partPost.ItemCode;
            part.Name = partPost.Name;
            part.Description = partPost.Description;
            part.QuantityInStock = partPost.QuantityInStock;
            part.ManufacturersCode = partPost.ManufacturersCode;
            part.ManufacturersName = partPost.ManufacturersName;
            part.LeadTimeDelivery = partPost.LeadTimeDelivery;
            part.UnitPricePurchase = partPost.UnitPricePurchase;
            part.UnitPriceSales = partPost.UnitPriceSales;
            part.Discount = partPost.Discount;
            part.VatRate = partPost.VatRate;
            part.SparePartImage = partPost.SparePartImage;

            _unitOfWork.SparePartsRepository.Delete(part);
            _unitOfWork.Save();
            _logger.LogInfo($"Part Id {partPost.Id} deleted");
        }
    }
}
