using Store.Application.Contracts.Supplier.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Supplier
{
    public interface ISupplierAppService
    {
        Task<SupplierDto> GetSupplierByIdAsync(int id);
        Task<List<SupplierDto>> GetAllSuppliersAsync();
        Task<bool> CreateSupplierAsync(CreateSupplierDto input);
        Task<bool> UpdateSupplierAsync(UpdateSupplierDto input);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
