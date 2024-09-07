using EcommerceAPR.model;

namespace EcommerceRPA.DTO
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }

        public int RamId { get; set; }
        public int RomId { get; set; }
        public int ProcessorId { get; set; }
        public int ColorId { get; set; }

        public string ImageUrl { get; set; }

        public decimal UnitPrice { get; set; }


        //public decimal SellingPrice { get; set; }





    }
}
