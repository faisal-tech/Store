using Store.Application.Contracts.Supplier.Dtos;
using Store.Application.Contracts.Supplier;
using Store.Domain.Entities;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Implementation
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierAppService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            return new SupplierDto
            {
                Id = supplier.Id,
                Name= supplier.Name,
            };
        }

        public async Task<List<SupplierDto>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return suppliers.Select(x => new SupplierDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async Task<bool> CreateSupplierAsync(CreateSupplierDto input)
        {
            await _supplierRepository.AddSupplierAsync(new Supplier
            {
                Name = input.Name,
            });
            return true;
        }

        public async Task<bool> UpdateSupplierAsync(UpdateSupplierDto input)
        {
            await _supplierRepository.UpdateSupplierAsync(new Supplier
            {
                Name=input.Name,
            });
            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            await _supplierRepository.DeleteSupplierAsync(id);
            return true;
        }
    }
}
