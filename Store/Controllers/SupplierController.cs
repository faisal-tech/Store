using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Supplier.Dtos;
using Store.Application.Contracts.Supplier;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAppService _supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplier = await _supplierAppService.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _supplierAppService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDto createSupplierDto)
        {
            var supplier = await _supplierAppService.CreateSupplierAsync(createSupplierDto);
            return Ok(supplier);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierDto updateSupplierDto)
        {
            var updatedSupplier = await _supplierAppService.UpdateSupplierAsync(updateSupplierDto);
            if (updatedSupplier == null)
                return NotFound();

            return Ok(updatedSupplier);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _supplierAppService.DeleteSupplierAsync(id);
            return NoContent();
        }
    }
}
