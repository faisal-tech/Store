using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contracts.Product.Dtos;

namespace Store.Application.Contracts.Product
{
    public interface IProductAppService
    {
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<bool> CreateProductAsync(CreateProductDto input);
        Task<bool> UpdateProductAsync(UpdateProductDto input);
        Task<bool> DeleteProductAsync(int id);
    }
}
