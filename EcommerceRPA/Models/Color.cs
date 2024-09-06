using System.ComponentModel.DataAnnotations;

namespace EcommerceAPR.model
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        [Required]
        public string ColorName { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}
