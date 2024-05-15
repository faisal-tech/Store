using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using Store.Domain.Entities;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<IEnumerable<Product>> GetAllProductsAsync(int page, int pageSize, string searchQuery)
		{
            IQueryable<Product> query = _context.Products;
            if (!string.IsNullOrEmpty(searchQuery))
			{
                query= query.Where(x =>
				x.Name.Contains(searchQuery));
            }


            return await query.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
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
	}

}
