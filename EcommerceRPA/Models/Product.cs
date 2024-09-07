using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EcommerceAPR.model;
using EcommerceRPA.DTO;

namespace EcommerceRPA.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey("FeatureId")]
        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public string ImageUrl { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
