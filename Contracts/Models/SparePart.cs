using System.Collections.Generic;

namespace Contracts.Models
{
    public class SparePart
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string Name { get; set; }
        public string ManufacturersCode { get; set; }
        public string ManufacturersName { get; set; }
        public string Description { get; set; }
        public string LeadTimeDelivery { get; set; }
        public int QuantityInStock { get; set; }
        public float UnitPriceSales { get; set; }
        public float UnitPricePurchase { get; set; }
        public int Discount { get; set; }
        public int VatRate { get; set; }
        public byte[] SparePartImage { get; set; }

        public ICollection<JobParts> JobParts { get; set; }
    }
}
