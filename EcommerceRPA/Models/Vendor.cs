using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceRPA.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        [StringLength(100)]
        public string VendorName { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        // Foreign Key for City
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        

        // Foreign Key for Company
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
