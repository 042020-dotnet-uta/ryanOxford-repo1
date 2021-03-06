﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project1.WebApp.Models
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }
        public SelectList Locations { get; set; }
        public string OrderLocation { get; set; }
        public string SearchString { get; set; }
    }
}
