
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Infrastructure.IRepositories;
using Store.Domain.Dtos;
using Store.Application.Contract.Product.Dtos;
using Store.Application.Contract.Product;
using Store.Application.Contracts.Dtos;
using Store.Domain.Entities;
using Store.Application.Contracts.Dtos.Statistics;
using FluentValidation;

namespace Store.Application.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
		private readonly IValidator<CreateProductDto> _createvalidator;
		private readonly IValidator<UpdateProductDto> _updatevalidator;

		public ProductAppService(IProductRepository productRepository
            , IValidator<CreateProductDto> createvalidator
            , IValidator<UpdateProductDto> updatevalidator)
        {
            _productRepository = productRepository;
			_createvalidator = createvalidator;
			_updatevalidator = updatevalidator;
		}

        public async Task<ApiResponseDto<ProductDto>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return ApiResponseDto<ProductDto>.IsSuccess(new ProductDto
            {
                Name = product.Name,
                UnitsInStock = product.StockUnit,
                SupplierId = product.SupplierId,
                OrderUnit = product.OrderUnit,
                Id = product.Id,
                UnitPrice = product.UnitPrice,
            });
        }

        public async Task<ApiResponseDto<PagingDto<ProductDto>>> GetAllProductsAsync(SearchFilterDto request)
        {
            var products = await _productRepository.GetAllProductsAsync(request.Offset, request.PageSize, request.SearchQuery, request.OrderBy);
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
                ReorderLimit = x.ReorderLimit,
                SupplierName = x.Supplier.Name,
            }).ToList();
            return ApiResponseDto<PagingDto<ProductDto>>.IsSuccess( new PagingDto<ProductDto>
            {
                Items = items,
                ItemsCount = products.ItemsCount,
            });

        }

        public async Task<ApiResponseDto<bool>> CreateProductAsync(CreateProductDto input)
        {
			var validationResult = await _createvalidator.ValidateAsync(input);
			if (!validationResult.IsValid)
			{
				var msgs = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                ApiResponseDto<bool>.IsError(msgs);
			}
			await _productRepository.AddProductAsync(new Store.Domain.Entities.Product
			{
                Name = input.Name,
                UnitId = input.UnitId,
                ReorderLimit = input.ReorderLimit,
                OrderUnit = input.OrderUnit,
                StockUnit = input.UnitsInStock,
                SupplierId = input.SupplierId,
                UnitPrice = input.UnitPrice,
            });
            return ApiResponseDto<bool>.IsSuccess(true);
        }

        public async Task<ApiResponseDto<bool>> UpdateProductAsync(UpdateProductDto input)
        {

            var validationResult = await _updatevalidator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                var msgs = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                ApiResponseDto<bool>.IsError(msgs);
            }
            await _productRepository.UpdateProductAsync(new Store.Domain.Entities.Product
			{
                Id = input.Id,
                Name = input.Name,
                UnitId = input.UnitId,
                ReorderLimit = input.ReorderLimit,
                OrderUnit = input.OrderUnit,
                StockUnit = input.UnitsInStock,
                SupplierId = input.SupplierId,
                UnitPrice = input.UnitPrice,
            });
            return ApiResponseDto<bool>.IsSuccess(true);
        }

        public async Task<ApiResponseDto<bool>> DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return ApiResponseDto<bool>.IsSuccess(true);
        }

        public async Task<ApiResponseDto<List<ProductInfo>>> GetProductsToReorderAsync()
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
            return ApiResponseDto<List<ProductInfo>>.IsSuccess(result);
        }
        public async Task<ApiResponseDto<List<ProductInfo>>> GetProductsWithMinimumOrdersAsync()
        {
            var productsToReorder = await _productRepository.GetProductsWithMinimumOrdersAsync();
            var result = productsToReorder.Select(x => new ProductInfo
            {
                Id = x.Id,
                Name = x.Name,
                ReorderLimit = x.ReorderLimit,
                StockUnit = x.StockUnit,
                SupplierName = x.SupplierName,
                OrderUnit = x.OrderUnit,
            }).ToList();
            return ApiResponseDto<List<ProductInfo>>.IsSuccess( result);
        }

    }
}
