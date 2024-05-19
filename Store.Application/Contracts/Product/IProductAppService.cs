using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contracts.Dtos;
using Store.Application.Contracts.Dtos.Statistics;
using Store.Application.Contracts.Product.Dtos;
using Store.Domain.Dtos;

namespace Store.Application.Contracts.Product
{
    public interface IProductAppService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<PagingDto<ProductDto>> GetAllProductsAsync(SearchFilterDto request);
        Task<bool> CreateProductAsync(CreateProductDto input);
        Task<bool> UpdateProductAsync(UpdateProductDto input);
        Task<bool> DeleteProductAsync(int id);
        Task<List<ProductInfo>> GetProductsToReorderAsync();
        Task<List<ProductInfo>> GetProductsWithMinimumOrdersAsync();

    }
}
