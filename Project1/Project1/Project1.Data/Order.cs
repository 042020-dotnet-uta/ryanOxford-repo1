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
    public class Order
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public ICollection<OrderProduct> Products { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Order Created Time")]
        public DateTime Created { get; set; }
        public Order() { }

    }
}
