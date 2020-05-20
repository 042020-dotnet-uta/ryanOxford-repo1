using Project1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class OrderAddProductViewModel
    {
        public List<Inventory> Inventories { get; set; }
        public int InventoryID { get; set; }
        public int Quantity { get; set; }
        public int TempOrderID { get; set; }
    }
}
