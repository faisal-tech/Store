using Store.Application.Contract.Supplier.Dtos;
using Store.Application.Contracts.Dtos;
using Store.Application.Contracts.Dtos.Statistics;
using Store.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contract.Supplier
{
    public interface ISupplierAppService
    {
        Task<ApiResponseDto<SupplierDto>> GetSupplierByIdAsync(int id);
        Task<ApiResponseDto<PagingDto<SupplierDto>>> GetAllSuppliersAsync(SearchFilterDto request);
        Task<ApiResponseDto<bool>> CreateSupplierAsync(CreateSupplierDto input);
        Task<ApiResponseDto<bool>> UpdateSupplierAsync(UpdateSupplierDto input);
        Task<ApiResponseDto<bool>> DeleteSupplierAsync(int id);
        Task<ApiResponseDto<List<SupplierInfoDto>>> GetLargestSuppliersAsync();
    }
}
