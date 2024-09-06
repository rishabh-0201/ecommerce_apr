using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EcommerceRPA.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        public decimal HighMarkup { get; set; }


        [Required]
        public decimal LowMarkup { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property for Vendors
        public ICollection<Vendor> Vendors { get; set; }
    }
}
