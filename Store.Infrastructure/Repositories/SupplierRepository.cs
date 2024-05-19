using Azure;
using Microsoft.EntityFrameworkCore;
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
	public class SupplierRepository : ISupplierRepository
	{
		private readonly ApplicationDbContext _context;

		public SupplierRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Supplier> GetSupplierByIdAsync(int id)
		{
			var supplier = await _context.Suppliers.FindAsync(id);
			if(supplier == null)
			{
				throw new KeyNotFoundException($"Supplier with ID {id} not found.");
			}
            return supplier;
		}

		public async Task<PagingDto<Supplier>> GetAllSuppliersAsync(int offset, int pageSize, string searchQuery, string orderBy)
		{
            IQueryable<Supplier> query =_context.Suppliers;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x =>
                x.Name.Contains(searchQuery));
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }
            var items = await query
				.Include(x => x.Products)
                .Skip(offset).Take(pageSize).ToListAsync();


            var result = new PagingDto<Supplier>
            {
                ItemsCount = await query.CountAsync(),
                Items = items
            };
			return result;
		}

		public async Task AddSupplierAsync(Supplier supplier)
		{
			_context.Suppliers.Add(supplier);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateSupplierAsync(Supplier supplier)
		{
			_context.Suppliers.Update(supplier);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteSupplierAsync(int id)
		{
			var supplier = await _context.Suppliers.FindAsync(id);
			if (supplier != null)
			{
				_context.Suppliers.Remove(supplier);
				await _context.SaveChangesAsync();
			}
		}
        public async Task<List<SupplierInfoDto>> GetLargestSuppliersAsync()
        {
            var query = await _context.Products
                .GroupBy(p => p.Supplier)
                .Select(g => new
                {
                    Supplier = g.Key,
                    ProductCount = g.Count()
                })
                .OrderByDescending(s => s.ProductCount)
                .ToListAsync();

            return query.Select(s => new SupplierInfoDto
            {
                Id = s.Supplier.Id,
                Name = s.Supplier.Name,
                ProductCount = s.ProductCount
            }).ToList();
        }
    }

}
