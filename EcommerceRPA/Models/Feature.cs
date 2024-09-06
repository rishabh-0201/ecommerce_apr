using EcommerceRPA.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPR.model
{
    public class Feature
    {

        [Key]
        public int FeatureId {  get; set; }

        [ForeignKey("ColorId")]
        public int ColorId { get; set; }
        public Color Color { get; set; }

        [ForeignKey("RamId")]
        public int RamId { get; set; }
        public RAM Ram { get; set; }

        [ForeignKey("RomId")]
        public int RomId { get; set; }
        public ROM Rom { get; set; }

        [ForeignKey("ProcessorId")]
        public int ProcessorId { get; set; }
        public Processor processor { get; set; }

        
        public ICollection<Product> Products { get; set; }
    }
}
