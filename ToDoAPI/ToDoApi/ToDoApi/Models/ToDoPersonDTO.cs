﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
    public class ToDoPersonDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
    }
}
