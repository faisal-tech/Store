using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contract.Product.Dtos;
using Store.Application.Contracts.Dtos;
using Store.Application.Contracts.Dtos.Statistics;
using Store.Domain.Dtos;

namespace Store.Application.Contract.Product
{
    public interface IProductAppService
    {
        Task<ApiResponseDto<ProductDto>> GetProductByIdAsync(int id);
        Task<ApiResponseDto<PagingDto<ProductDto>>> GetAllProductsAsync(SearchFilterDto request);
        Task<ApiResponseDto<bool>> CreateProductAsync(CreateProductDto input);
        Task<ApiResponseDto<bool>> UpdateProductAsync(UpdateProductDto input);
        Task<ApiResponseDto<bool>> DeleteProductAsync(int id);
        Task<ApiResponseDto<List<ProductInfo>>> GetProductsToReorderAsync();
        Task<ApiResponseDto<List<ProductInfo>>> GetProductsWithMinimumOrdersAsync();

    }
}
