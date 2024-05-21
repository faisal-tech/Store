using Store.Domain.Dtos;
using Store.Domain.Dtos.StatisiticsDto;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.IRepositories
{
	public interface IProductRepository
	{
		Task<Product> GetProductByIdAsync(int id);
		Task<PagingDto<Product>> GetAllProductsAsync(int offset, int pageSize,string searchQuery,string orderBy);
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
		Task<List<ProductInfo>> GetProductsToReorderAsync();
		Task<List<ProductInfo>> GetProductsWithMinimumOrdersAsync();

    }
}
