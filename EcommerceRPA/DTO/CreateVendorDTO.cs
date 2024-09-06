namespace EcommerceRPA.DTO
{
    public class CreateVendorDTO
    {

        public string VendorName { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
      
        public int CompanyId { get; set; }
    }
}
