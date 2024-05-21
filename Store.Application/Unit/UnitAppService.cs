using Store.Application.Contracts.Unit.Dtos;
using Store.Application.Contracts.Unit;
using Store.Domain.Lookups;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Dtos;

namespace Store.Application.Unit
{
    public class UnitAppService : IUnitAppService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitAppService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<ApiResponseDto<List<UnitDto>>> GetAllUnitsAsync()
        {
            var units = await _unitRepository.GetAllUnitsAsync();
            return ApiResponseDto<List<UnitDto>>.IsSuccess(units.Select(x => new UnitDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList());
        }

    }
}
