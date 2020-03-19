namespace Contracts.Models
{
    public class JobParts
    {
        public int JobCardId { get; set; }
        public JobCard JobCard { get; set; }

        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; }

        public int QuantityInstalled { get; set; }
    }
}
