using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Dtos.Statistics
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockUnit { get; set; }
        public int ReorderLimit { get; set; }
        public string SupplierName{ get; set; }
        public int OrderUnit { get; set; }
    }
}
