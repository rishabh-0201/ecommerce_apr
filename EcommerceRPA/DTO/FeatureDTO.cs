using System.ComponentModel.DataAnnotations;

namespace EcommerceRPA.DTO
{
    public class FeatureDTO
    {

        [Key]
        public int FeatureId { get; set; }
        public int RamId { get; set; }

        public int RomId { get; set; }

        public int ColorId { get; set; }



        public int ProcessorId { get; set; }


    }
}
