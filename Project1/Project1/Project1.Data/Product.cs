using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;
using Project1.BusinessLogic;

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
        [Required]
        [RegularExpression(InputPrompts.productPattern,ErrorMessage = InputPrompts.productError)]
        public string Name { get; set; }
        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        [Range(0.0, 1000000, ErrorMessage = "The price must be greater than 0 and less than 1000000")]
        [Required]
        public decimal Price { get; set; }
        public Product() { }
    }
}
