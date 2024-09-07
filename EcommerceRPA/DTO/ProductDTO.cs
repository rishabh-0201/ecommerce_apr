namespace EcommerceRPA.DTO
{
    public class ProductDTO
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }

        public int FeatureId { get; set; }
        public string ImageUrl { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
