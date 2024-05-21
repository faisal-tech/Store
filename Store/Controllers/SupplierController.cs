using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Dtos;
using Store.Domain.Dtos;
using Store.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Store.Application.Contracts.Dtos.Statistics;
using Store.Application.Contract.Supplier;
using Store.Application.Contract.Supplier.Dtos;
using Azure;

namespace Store.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAppService _supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponseDto<SupplierDto>> GetSupplier(int id)
        {
            var response = await _supplierAppService.GetSupplierByIdAsync(id);
         

            return response;
        }

        [HttpGet]
        public async Task<ApiResponseDto<PagingDto<SupplierDto>>> SuppliersList([FromQuery] SearchFilterDto request)
        {
            var response = await _supplierAppService.GetAllSuppliersAsync(request);
            return response;
        }

        [HttpPost]
        public async Task<ApiResponseDto<bool>> CreateSupplier([FromBody] CreateSupplierDto createSupplierDto)
        {
            var response = await _supplierAppService.CreateSupplierAsync(createSupplierDto);
            
            return response;
        }

        [HttpPut]
        public async Task<ApiResponseDto<bool>> UpdateSupplier([FromBody] UpdateSupplierDto updateSupplierDto)
        {
            var response = await _supplierAppService.UpdateSupplierAsync(updateSupplierDto);
            

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponseDto<bool>> DeleteSupplier(int id)
        {
            var response = await _supplierAppService.DeleteSupplierAsync(id);
          

            return response;

        }
        [HttpGet]
        public async Task<ApiResponseDto<List<SupplierInfoDto>>> GetLargestSupplier()
        {
            var response = await _supplierAppService.GetLargestSuppliersAsync();
            return response;
        }

    }
}
