using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Unit.Dtos;
using Store.Application.Contracts.Unit;
using Store.Domain.Entities;
using Store.Application.Contracts.Supplier.Dtos;
using Store.Domain.Dtos;
using Store.Domain.Lookups;
using Store.Infrastructure.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitAppService _unitAppService;

        public UnitController(IUnitAppService unitAppService)
        {
            _unitAppService = unitAppService;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponseDto<UnitDto>> GetUnit(int id)
        {
            var unit = await _unitAppService.GetUnitByIdAsync(id);
            if (unit == null)
                throw new InvalidOperationException("Unit was not found");

            return new ApiResponseDto<UnitDto>().IsSuccess(unit);
        }

        [HttpGet]
        public async Task<ApiResponseDto<List<UnitDto>>> GetAllUnits()
        {
            var units = await _unitAppService.GetAllUnitsAsync();
            return new ApiResponseDto<List<UnitDto>>().IsSuccess(units);
        }

        [HttpPost]
        public async Task<ApiResponseDto<bool>> CreateUnit(CreateUnitDto createUnitDto)
        {
            var isCreated = await _unitAppService.CreateUnitAsync(createUnitDto);
            if (isCreated == false)
                throw new InvalidOperationException("Internal Server Error");


            return new ApiResponseDto<bool>().IsSuccess(isCreated);

        }

        [HttpPut]
        public async Task<ApiResponseDto<bool>> UpdateUnit([FromBody] UpdateUnitDto updateUnitDto)
        {
            var isUpdated = await _unitAppService.UpdateUnitAsync(updateUnitDto);
            if (isUpdated == false)
                throw new InvalidOperationException("Internal Server Error");

            return new ApiResponseDto<bool>().IsSuccess(isUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponseDto<bool>> DeleteUnit(int id)
        {
            var isDeleted = await _unitAppService.DeleteUnitAsync(id);
            if (isDeleted == false)
                throw new InvalidOperationException("Internal Server Error");

            return new ApiResponseDto<bool>().IsSuccess(isDeleted);
        }
    }
}
