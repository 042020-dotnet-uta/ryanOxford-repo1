﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedLib
{
    public class Fruit
    {
        public string Name { get; set; }
        public Fruit() { }
        public override string ToString()
        {
            return Name;
        }
    }

}
