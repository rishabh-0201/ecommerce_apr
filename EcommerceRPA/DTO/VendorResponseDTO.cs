﻿namespace EcommerceRPA.DTO
{
    public class VendorResponseDTO
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int StateId { get; set; }

        public string CompanyName { get; set; }
        public string StateName { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
