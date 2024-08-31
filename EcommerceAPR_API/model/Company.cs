using System.ComponentModel.DataAnnotations;

namespace EcommerceAPR.model
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property for Vendors
        public ICollection<Vendor> Vendors { get; set; }
    }
}
