using System.ComponentModel.DataAnnotations;

namespace EcommerceRPA.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //public ICollection<Product> Products { get; set; }


    }
}
