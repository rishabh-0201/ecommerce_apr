using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommerceAPR.model
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        // Foreign Key for State
        [ForeignKey("State")]
        public int StateId { get; set; }
        public State State { get; set; }

        // Navigation property for Vendors
        public ICollection<Vendor> Vendors { get; set; }
    }
}
