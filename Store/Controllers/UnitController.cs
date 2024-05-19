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

        [HttpGet]
        public async Task<ApiResponseDto<List<UnitDto>>> GetAllUnits()
        {
            var units = await _unitAppService.GetAllUnitsAsync();
            return ApiResponseDto<List<UnitDto>>.IsSuccess(units);
        }
    }
}