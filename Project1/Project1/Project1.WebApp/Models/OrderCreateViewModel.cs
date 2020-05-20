using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Project1.Data;

namespace Project1.WebApp.Models
{
    public class OrderCreateViewModel
    {
        public SelectList Locations { get; set; }
        public List<Customer> Customers { get; set; }
        public string LocationName { get; set; }
        public int CustomerID { get; set; }
    }
}
