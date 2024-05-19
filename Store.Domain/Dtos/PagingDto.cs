using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Dtos
{
    public class PagingDto<T>
    {
        public int ItemsCount { get; set; }
        public List<T> Items { get; set; }
    }
}
