﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Dtos.StatisiticsDto
{
    public class SupplierInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}
