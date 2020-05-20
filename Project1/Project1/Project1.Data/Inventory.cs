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
        [Range(0,10000,ErrorMessage ="Must be greater than 0 and less than 10000")]
        public int Quantity { get; set; }

        public Inventory() { }
    }
}
