using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Supplier.Dtos;
using Store.Application.Contracts.Supplier;
using Store.Application.Contracts.Dtos;
using Store.Domain.Dtos;
using Store.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Store.Application.Contracts.Dtos.Statistics;

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
            var supplier = await _supplierAppService.GetSupplierByIdAsync(id);
            if (supplier == null)
                throw new InvalidOperationException("Supplier was not found");

            return ApiResponseDto<SupplierDto>.IsSuccess(supplier);
        }

        [HttpGet]
        public async Task<ApiResponseDto<PagingDto<SupplierDto>>> SuppliersList([FromQuery] SearchFilterDto request)
        {
            var suppliers = await _supplierAppService.GetAllSuppliersAsync(request);
            return ApiResponseDto<PagingDto<SupplierDto>>.IsSuccess(suppliers);
        }

        [HttpPost]
        public async Task<ApiResponseDto<bool>> CreateSupplier([FromBody] CreateSupplierDto createSupplierDto)
        {
            var isCreated = await _supplierAppService.CreateSupplierAsync(createSupplierDto);
            if (isCreated == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }
            return ApiResponseDto<bool>.IsSuccess(isCreated);
        }

        [HttpPut]
        public async Task<ApiResponseDto<bool>> UpdateSupplier([FromBody] UpdateSupplierDto updateSupplierDto)
        {
            var isUpdated = await _supplierAppService.UpdateSupplierAsync(updateSupplierDto);
            if (isUpdated == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }

            return ApiResponseDto<bool>.IsSuccess(isUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponseDto<bool>> DeleteSupplier(int id)
        {
            var isDeleted = await _supplierAppService.DeleteSupplierAsync(id);
            if (isDeleted == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }

            return ApiResponseDto<bool>.IsSuccess(isDeleted);

        }
        [HttpGet]
        public async Task<ApiResponseDto<List<SupplierInfoDto>>> GetLargestSupplier()
        {
            var suppliers = await _supplierAppService.GetLargestSuppliersAsync();
            return ApiResponseDto<List<SupplierInfoDto>>.IsSuccess(suppliers);
        }

    }
}
