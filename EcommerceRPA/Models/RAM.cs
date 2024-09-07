using System.ComponentModel.DataAnnotations;

namespace EcommerceAPR.model
{
    public class RAM
    {

        [Key]
        public int RamId { get; set; }

        [Required]
        public string RamValue { get; set; }

        public ICollection<Feature> Features { get; set; }

    }
}
