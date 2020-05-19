using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Data
{
    /// <summary>
    /// Model for the Product class
    /// </summary>
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Product")]
        public string Name { get; set; }
        public string Description { get; set; }
        public Product() { }
    }
}
