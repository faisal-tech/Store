using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using Store.Domain.Dtos;
using Store.Domain.Entities;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Store.Domain.Dtos.StatisiticsDto;
namespace Store.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _context.Products.FindAsync(id);
		}

		public async Task<PagingDto<Product>> GetAllProductsAsync(int offset, int pageSize, string searchQuery,string orderBy)
		{
            IQueryable<Product> query = _context.Products;
            if (!string.IsNullOrEmpty(searchQuery))
			{
                query= query.Where(x =>
				x.Name.Contains(searchQuery));
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }

            var items = await query
				.Include(x=>x.Supplier)
				.Include(x=>x.Unit)
				.Skip(offset).Take(pageSize).ToListAsync();
			var result = new PagingDto<Product>
			{
				ItemsCount = await query.CountAsync(),
				Items= items
            };

            return result;
		}

		public async Task AddProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int id)
		{
			var product = await _context.Products.FindAsync(id);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}
        public async Task<List<ProductInfo>> GetProductsToReorderAsync()
        {
            var productsToReorder = await _context.Products
                .Where(p => p.StockUnit < p.ReorderLimit)
                .Select(p => new ProductInfo
                {
                    Id = p.Id,
                    Name = p.Name,
                    StockUnit = p.StockUnit,
                    ReorderLimit = p.ReorderLimit,
                    SupplierName= p.Supplier.Name
                })
                .ToListAsync();

            return productsToReorder;
        }

        public async Task<List<ProductInfo>> GetProductsWithMinimumOrdersAsync()
        {
            var productsWithMinimumOrders = await _context.Products
                .Where(p => p.OrderUnit >= p.ReorderLimit)
                .Select(p => new ProductInfo
                {
                    Id = p.Id,
                    Name = p.Name,
                    StockUnit = p.StockUnit,
                    ReorderLimit = p.ReorderLimit,
                    SupplierName = p.Supplier.Name,
                    OrderUnit = p.OrderUnit,
                })
                .ToListAsync();

            return productsWithMinimumOrders;
        }

    }

}
