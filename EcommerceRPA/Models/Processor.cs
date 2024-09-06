using System.ComponentModel.DataAnnotations;

namespace EcommerceAPR.model
{
    public class Processor
    {
        [Key]
        public int ProcessorId { get; set; }

        [Required]
        public string ProcessorValue { get; set; }

        public ICollection<Feature> Features { get; set; }

    }
}
