﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceRPA.Models
{
    public class State
    {

        [Key]
        public int StateId { get; set; }

        [Required]
        [StringLength(100)]
        public string StateName { get; set; }

        // Navigation property for Cities
        public ICollection<City> Cities { get; set; }

      
    }
}
