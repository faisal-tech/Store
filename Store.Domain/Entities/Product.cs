using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReorderLimit { get; set; }
        public string UnitPrice { get; set; }
        public int SockUnit { get; set; }
        public int OrderUnit { get; set; }
    }
}
