using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Dtos
{
    public class SearchFilterDto
    {
        public int Offset { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public string? SearchQuery { get; set; }
        public string? OrderBy { get; set; }
    }
}
