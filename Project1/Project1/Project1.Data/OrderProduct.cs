using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.Data
{
    /// <summary>
    /// Model for the OrderProduct class
    /// </summary>
    public class OrderProduct
    {
        public int ID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public OrderProduct() { }
    }
}
