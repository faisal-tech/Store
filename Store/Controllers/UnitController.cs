using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Unit.Dtos;
using Store.Application.Contracts.Unit;

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
        public async Task<IActionResult> GetUnit(int id)
        {
            var unit = await _unitAppService.GetUnitByIdAsync(id);
            if (unit == null)
                return NotFound();

            return Ok(unit);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var units = await _unitAppService.GetAllUnitsAsync();
            return Ok(units);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUnit(CreateUnitDto createUnitDto)
        {
            var unit = await _unitAppService.CreateUnitAsync(createUnitDto);
            return Ok(unit);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUnit([FromBody] UpdateUnitDto updateUnitDto)
        {
            var updatedUnit = await _unitAppService.UpdateUnitAsync(updateUnitDto);
            if (updatedUnit == null)
                return NotFound();

            return Ok(updatedUnit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            await _unitAppService.DeleteUnitAsync(id);
            return NoContent();
        }
    }
}
