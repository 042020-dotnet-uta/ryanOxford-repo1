using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project1.WebApp.Models
{
    public class InventoryViewModel
    {
        public List<Inventory> InventoryItems { get; set; }
        public SelectList Locations { get; set; }
        public string ProductLocation { get; set; }
        public string SearchString { get; set; }

    }
}
