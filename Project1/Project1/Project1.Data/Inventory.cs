using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Data
{
    /// <summary>
    /// Model for the Inventory class
    /// </summary>
    public class Inventory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Location Location { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Inventory() { }
    }
}
