﻿using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Lookups
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products{ get; set; }
    }
}
