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
	public interface ISupplierRepository
	{
		Task<Supplier> GetSupplierByIdAsync(int id);
		Task<PagingDto<Supplier>> GetAllSuppliersAsync(int offset, int pageSize, string searchQuery,string orderBy);
		Task AddSupplierAsync(Supplier supplier);
		Task UpdateSupplierAsync(Supplier supplier);
		Task DeleteSupplierAsync(int id);
		Task<List<SupplierInfoDto>> GetLargestSuppliersAsync();

    }
}
