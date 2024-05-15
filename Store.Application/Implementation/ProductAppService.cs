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
                SockUnit = product.SockUnit,
                SupplierId = product.SupplierId,
                OrderUnit = product.OrderUnit,
                Id = product.Id,
                UnitPrice = product.UnitPrice,
            };
        }

        public async Task<List<ProductDto>> GetAllProductsAsync(SearchFilterDto request)
        {
            var products = await _productRepository.GetAllProductsAsync(request.Page,request.PageSize,request.SearchQuery) ;
            return products.Select(x=>new ProductDto
            {
                Name = x.Name,
                SockUnit = x.SockUnit,
                SupplierId = x.SupplierId,
                OrderUnit = x.OrderUnit,
                Id = x.Id,
                UnitPrice = x.UnitPrice,

            }).ToList();
        }

        public async Task<bool> CreateProductAsync(CreateProductDto input)
        {
            await _productRepository.AddProductAsync(new Product
            {
                Name= input.Name,
                UnitId= input.UnitId,
                ReorderLimit= input.ReorderLimit,
                OrderUnit= input.OrderUnit,
                SockUnit= input.SockUnit,
                SupplierId= input.SupplierId,
                UnitPrice= input.UnitPrice,
            });
            return true;
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto input)
        {
            await _productRepository.UpdateProductAsync(new Product
            {
                Name = input.Name,
                UnitId = input.UnitId,
                ReorderLimit = input.ReorderLimit,
                OrderUnit = input.OrderUnit,
                SockUnit = input.SockUnit,
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
    }
}
