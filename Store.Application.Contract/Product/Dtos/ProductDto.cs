using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contract.Product.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int ReorderLimit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitId { get; set; }
        public int UnitsInStock { get; set; }
        public string Unit { get; set; }
        public int OrderUnit { get; set; }
    }
}
