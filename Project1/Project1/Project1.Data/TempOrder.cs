using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project1.Data
{
    /// <summary>
    /// Model for the Order class
    /// </summary>
    public class TempOrder
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Location Location { get; set; }
        public ICollection<TempOrderProduct> Products { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Order Created Time")]
        public DateTime Created { get; set; }
        public TempOrder() { }

    }
}
