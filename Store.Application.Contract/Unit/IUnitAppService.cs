using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contracts.Unit.Dtos;
using Store.Domain.Dtos;

namespace Store.Application.Contracts.Unit
{
    public interface IUnitAppService
    {
        Task<ApiResponseDto<List<UnitDto>>> GetAllUnitsAsync();
    }
}
