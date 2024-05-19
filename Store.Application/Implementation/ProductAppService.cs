using Store.Application.Contracts.Product.Dtos;
using Store.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Infrastructure.IRepositories;
using Store.Domain.Entities;
using Store.Domain.Lookups;
using Azure.Core;
using Store.Application.Contracts.Dtos;
using Store.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Store.Application.Contracts.Dtos.Statistics;

namespace Store.Application.Implementation
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return new ProductDto
            {
                Name = product.Name,
                UnitsInStock = product.StockUnit,
                SupplierId = product.SupplierId,
                OrderUnit = product.OrderUnit,
                Id = product.Id,
                UnitPrice = product.UnitPrice,
            };
        }

        public async Task<PagingDto<ProductDto>> GetAllProductsAsync(SearchFilterDto request)
        {
            var products = await _productRepository.GetAllProductsAsync(request.Offset,request.PageSize,request.SearchQuery, request.OrderBy);
            var items = products.Items.Select(x => new ProductDto
            {
                Name = x.Name,
                UnitsInStock = x.StockUnit,
                SupplierId = x.SupplierId,
                OrderUnit = x.OrderUnit,
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                Unit = x.Unit.Name,
                UnitId = x.UnitId,
                ReorderLimit=x.ReorderLimit,
                SupplierName =x.Supplier.Name,
            }).ToList();
            return new PagingDto<ProductDto>
            {
                Items = items,
                ItemsCount=products.ItemsCount,
            };
             
        }

        public async Task<bool> CreateProductAsync(CreateProductDto input)
        {
            await _productRepository.AddProductAsync(new Product
            {
                Name= input.Name,
                UnitId= input.UnitId,
                ReorderLimit= input.ReorderLimit,
                OrderUnit= input.OrderUnit,
                StockUnit= input.UnitsInStock,
                SupplierId= input.SupplierId,
                UnitPrice= input.UnitPrice,
            });
            return true;
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto input)
        {
            await _productRepository.UpdateProductAsync(new Product
            {
                Id= input.Id,
                Name = input.Name,
                UnitId = input.UnitId,
                ReorderLimit = input.ReorderLimit,
                OrderUnit = input.OrderUnit,
                StockUnit = input.UnitsInStock,
                SupplierId = input.SupplierId,
                UnitPrice = input.UnitPrice,
            });
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return true;
        }

        public async Task<List<ProductInfo>> GetProductsToReorderAsync()
        {
           var productsToReorder = await _productRepository.GetProductsToReorderAsync();
            var result = productsToReorder.Select(x => new ProductInfo
            {
                Id = x.Id,
                Name = x.Name,
                ReorderLimit = x.ReorderLimit,
                StockUnit = x.StockUnit,
                SupplierName = x.SupplierName
            }).ToList();
            return result;
        }
        public async Task<List<ProductInfo>> GetProductsWithMinimumOrdersAsync()
        {
           var productsToReorder = await _productRepository.GetProductsWithMinimumOrdersAsync();
            var result = productsToReorder.Select(x => new ProductInfo
            {
                Id = x.Id,
                Name = x.Name,
                ReorderLimit = x.ReorderLimit,
                StockUnit = x.StockUnit,
                SupplierName = x.SupplierName,
                OrderUnit= x.OrderUnit,
            }).ToList();
            return result;
        }

    }
}
