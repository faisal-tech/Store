using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			return await _context.Suppliers.FindAsync(id);
		}

		public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
		{
			return await _context.Suppliers.ToListAsync();
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
	}

}
