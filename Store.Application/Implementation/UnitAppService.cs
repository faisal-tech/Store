using Store.Application.Contracts.Unit.Dtos;
using Store.Application.Contracts.Unit;
using Store.Domain.Lookups;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Implementation
{
    public class UnitAppService : IUnitAppService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitAppService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<UnitDto> GetUnitByIdAsync(int id)
        {
            var unit = await _unitRepository.GetUnitByIdAsync(id);
            return new UnitDto
            {
                Id= unit.Id,
                Name = unit.Name,
            };
        }

        public async Task<List<UnitDto>> GetAllUnitsAsync()
        {
            var units = await _unitRepository.GetAllUnitsAsync();
            return units.Select(x=>new UnitDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async Task<bool> CreateUnitAsync(CreateUnitDto input)
        {
            await _unitRepository.AddUnitAsync(new Unit
            {
                Name=input.Name,
            });
            return true;
        }

        public async Task<bool> UpdateUnitAsync(UpdateUnitDto input)
        {
            await _unitRepository.UpdateUnitAsync(new Unit
            {
                Id = input.Id,
                Name = input.Name,
            });
            return true;
        }

        public async Task<bool> DeleteUnitAsync(int id)
        {
            await _unitRepository.DeleteUnitAsync(id);
            return true;
        }
    }
}
