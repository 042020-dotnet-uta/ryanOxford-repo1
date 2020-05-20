using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class ToDoPerson
    {
        public long ID { get; set; }
        public string Name { get;set;}
        public bool IsAvailable { get; set; }
        public string secret { get; set; }
    }
}
