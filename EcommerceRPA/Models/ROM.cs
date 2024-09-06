using System.ComponentModel.DataAnnotations;

namespace EcommerceAPR.model
{
    public class ROM
    {
        [Key]
        public int RomId { get; set; }

        [Required]
        public string RomValue { get; set; }

        public ICollection<Feature> Features { get; set; }
    }
}
