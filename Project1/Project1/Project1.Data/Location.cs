using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project1.Data
{
    /// <summary>
    /// Model for the Location class
    /// </summary>
    public class Location
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Location")]
        public string Name { get; set; }
        public Location() { }

    }
}
