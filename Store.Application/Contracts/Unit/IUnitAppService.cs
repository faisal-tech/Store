using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contracts.Unit.Dtos;

namespace Store.Application.Contracts.Unit
{
    public interface IUnitAppService
    {
        Task<UnitDto> GetUnitByIdAsync(int id);
        Task<List<UnitDto>> GetAllUnitsAsync();
        Task<bool> CreateUnitAsync(CreateUnitDto input);
        Task<bool> UpdateUnitAsync(UpdateUnitDto input);
        Task<bool> DeleteUnitAsync(int id);
    }
}
