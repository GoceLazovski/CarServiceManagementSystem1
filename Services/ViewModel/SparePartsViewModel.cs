using Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.ViewModels
{
    public class SparePartsViewModel
    {
        public SparePartsViewModel()
        {

        }
        public SparePartsViewModel(SparePart parts)
        {
            Id = parts.Id;
            ItemCode = parts.ItemCode;
            Name = parts.Name;
            ManufacturersCode = parts.ManufacturersCode;
            ManufacturersName = parts.ManufacturersName;
            Description = parts.Description;
            LeadTimeDelivery = parts.LeadTimeDelivery;
            QuantityInStock = parts.QuantityInStock;
            UnitPriceSales = parts.UnitPriceSales;
            UnitPricePurchase = parts.UnitPricePurchase;
            Discount = parts.Discount;
            VatRate = parts.VatRate;
            SparePartImage = parts.SparePartImage;
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Item Code")]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Manufacturers Code")]
        public string ManufacturersCode { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Manufacturers Name")]
        public string ManufacturersName { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Lead Time Delivery")]
        public string LeadTimeDelivery { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive value")]
        [Display(Name = "Quantity In Stock")]
        public int QuantityInStock { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter a value betveen 1 and 1000")]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price Sales")]
        public float UnitPriceSales { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter a value betveen 1 and 1000")]
        [DataType(DataType.Currency)]
        [Display(Name = "Unit Price Purchase")]
        public float UnitPricePurchase { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Please enter a value betveen 0 and 100")]
        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Please enter a value betveen 0 and 100")]
        [Display(Name = "Vat Rate")]
        public int VatRate { get; set; }

        public byte[] SparePartImage { get; set; }

        public ICollection<JobPartsViewModel> JobParts { get; set; }
    }
}
