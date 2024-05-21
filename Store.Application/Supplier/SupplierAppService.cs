
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
using Store.Application.Contract.Supplier.Dtos;
using Store.Application.Contract.Supplier;
using Store.Application.Product;
using FluentValidation;

namespace Store.Application.Supplier
{
	public class SupplierAppService : ISupplierAppService
	{
		private readonly ISupplierRepository _supplierRepository;
		private readonly IValidator<CreateSupplierDto> _createSupplierValidator;
		private readonly IValidator<UpdateSupplierDto> _updateSupplierValidator;

		public SupplierAppService(ISupplierRepository supplierRepository, IValidator<CreateSupplierDto> createSupplierValidator
			, IValidator<UpdateSupplierDto> updateSupplierValidator)
		{
			_supplierRepository = supplierRepository;
			_createSupplierValidator = createSupplierValidator;
			_updateSupplierValidator = updateSupplierValidator;
		}

		public async Task<ApiResponseDto<SupplierDto>> GetSupplierByIdAsync(int id)
		{
			var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
			return ApiResponseDto<SupplierDto>.IsSuccess(new SupplierDto
			{
				Id = supplier.Id,
				Name = supplier.Name,
			});
		}

		public async Task<ApiResponseDto<PagingDto<SupplierDto>>> GetAllSuppliersAsync(SearchFilterDto request)
		{
			var response = await _supplierRepository.GetAllSuppliersAsync(request.Offset, request.PageSize, request.SearchQuery, request.OrderBy);
			var items = response.Items.Select(x => new SupplierDto
			{
				Id = x.Id,
				Name = x.Name,
				ProductCount = x.Products.Count,
			}).ToList();

			return ApiResponseDto<PagingDto<SupplierDto>>.IsSuccess(new PagingDto<SupplierDto>
			{
				Items = items,
				ItemsCount = response.ItemsCount,
			});
		}

		public async Task<ApiResponseDto<bool>> CreateSupplierAsync(CreateSupplierDto input)
		{

			var validationResult = await _createSupplierValidator.ValidateAsync(input);
			if (!validationResult.IsValid)
			{
				var msgs = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

				return ApiResponseDto<bool>.IsError(msgs);
			}

			await _supplierRepository.AddSupplierAsync(new Store.Domain.Entities.Supplier
			{
				Name = input.Name,
			});
			return ApiResponseDto<bool>.IsSuccess(true);
		}

		public async Task<ApiResponseDto<bool>> UpdateSupplierAsync(UpdateSupplierDto input)
		{
			var validationResult = await _updateSupplierValidator.ValidateAsync(input);
			if (!validationResult.IsValid)
			{
				var msgs = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

				return ApiResponseDto<bool>.IsError(msgs);
			}

			await _supplierRepository.UpdateSupplierAsync(new Store.Domain.Entities.Supplier
			{
				Id = input.Id,
				Name = input.Name,
			});
			return ApiResponseDto<bool>.IsSuccess(true);
		}

		public async Task<ApiResponseDto<bool>> DeleteSupplierAsync(int id)
		{
			await _supplierRepository.DeleteSupplierAsync(id);
			return ApiResponseDto<bool>.IsSuccess(true);
		}

		public async Task<ApiResponseDto<List<SupplierInfoDto>>> GetLargestSuppliersAsync()
		{
			var result = await _supplierRepository.GetLargestSuppliersAsync();
			var response = result.Select(x => new SupplierInfoDto
			{
				Id = x.Id,
				Name = x.Name,
				ProductCount = x.ProductCount,
			}).ToList();
			return ApiResponseDto<List<SupplierInfoDto>>.IsSuccess(response);
		}
	}
}
