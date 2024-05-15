using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.IRepositories
{
	public interface ISupplierRepository
	{
		Task<Supplier> GetSupplierByIdAsync(int id);
		Task<IEnumerable<Supplier>> GetAllSuppliersAsync(int page, int pageSize, string searchQuery);
		Task AddSupplierAsync(Supplier supplier);
		Task UpdateSupplierAsync(Supplier supplier);
		Task DeleteSupplierAsync(int id);
	}
}
