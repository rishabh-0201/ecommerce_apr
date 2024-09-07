using EcommerceAPR.model;

namespace EcommerceRPA.DTO
{
    public class ProductResponseDTO
    {

        public string ProductName { get; set; }
        public string ProductDescription { get; set;}
        public string ColorName { get; set; } 
        public string RamValue { get; set; }
        public string ProcessorValue { get; set; }
        public string RomValue { get; set; }
        public string ImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? SellingPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
