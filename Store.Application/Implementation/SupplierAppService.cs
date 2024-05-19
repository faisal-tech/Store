using Store.Application.Contracts.Supplier.Dtos;
using Store.Application.Contracts.Supplier;
using Store.Domain.Entities;
using Store.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Application.Contracts.Dtos;
using Store.Domain.Dtos;
using Store.Application.Contracts.Dtos.Statistics;

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
        
        public async Task<PagingDto<SupplierDto>> GetAllSuppliersAsync(SearchFilterDto request)
        {
            var response = await _supplierRepository.GetAllSuppliersAsync(request.Offset,request.PageSize,request.SearchQuery,request.OrderBy);
            var items = response.Items.Select(x => new SupplierDto
            {
                Id = x.Id,
                Name = x.Name,
                ProductCount=x.Products.Count,
            }).ToList();

            return new PagingDto<SupplierDto>
            {
                Items = items,
                ItemsCount = response.ItemsCount,
            };
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
                Id=input.Id,
                Name=input.Name,
            });
            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            await _supplierRepository.DeleteSupplierAsync(id);
            return true;
        }

        public async Task<List<SupplierInfoDto>> GetLargestSuppliersAsync()
        {
            var result = await _supplierRepository.GetLargestSuppliersAsync();
            var response = result.Select(x => new SupplierInfoDto
            {
                Id = x.Id,
                Name = x.Name,
                ProductCount = x.ProductCount,
            }).ToList();
            return response;
        }
    }
}
