using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Data
{
    /// <summary>
    /// Model for the OrderProduct class
    /// </summary>
    public class OrderProduct
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        [Range(0, 10000, ErrorMessage = "Must be greater than 0 and less than 10000")]
        public int Quantity { get; set; }
        public OrderProduct() { }
    }
}
