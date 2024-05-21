using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contract.Product.Dtos
{
    public class UpdateProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public int SupplierId { get; set; }
        public int ReorderLimit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int OrderUnit { get; set; }
    }
}
