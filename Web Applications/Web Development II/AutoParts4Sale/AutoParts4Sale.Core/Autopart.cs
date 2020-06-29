﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoParts4Sale.Core
{
    public class Autopart
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public CarMake CarMake{ get; set; }
        public CarModel CarModel { get; set; }
        public Category Category { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Autopart()
        {
            DateAdded = DateTime.UtcNow;
            ModifiedDate = DateTime.UtcNow;
        }
    }
}