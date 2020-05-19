using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Project1.WebApp.Models
{
    public class InventoryCreateViewModel
    {
        public SelectList Products { get; set; }
        public SelectList Locations { get; set; }
        [Range(1,100)]
        public int Quantity { get; set; }
        [Required(ErrorMessage ="Please select a location")]
        public string InventoryLocation { get; set; }
        [Required(ErrorMessage = "Please select a product")]
        public string InventoryProduct { get; set; }
        public string ErrorMessage { get; set; }
    }
}
