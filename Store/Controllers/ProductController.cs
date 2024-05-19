using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Dtos;
using Store.Application.Contracts.Dtos.Statistics;
using Store.Application.Contracts.Product;
using Store.Application.Contracts.Product.Dtos;
using Store.Domain.Dtos;
using Store.Domain.Entities;

namespace Store.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet("{id}")]
        public async Task<ApiResponseDto<ProductDto>> GetProduct(int id)
        {
            var product = await _productAppService.GetProductByIdAsync(id);
            if (product == null)
                throw new InvalidOperationException("Product was not found");

            return ApiResponseDto<ProductDto>.IsSuccess(product);
        }

        [HttpGet]
        public async Task<ApiResponseDto<PagingDto<ProductDto>>> ProductsList([FromQuery]SearchFilterDto request)
        {
            var products = await _productAppService.GetAllProductsAsync(request);
            return ApiResponseDto<PagingDto<ProductDto>>.IsSuccess(products);
        }

        [HttpPost]
        public async Task<ApiResponseDto<bool>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var isSaved = await _productAppService.CreateProductAsync(createProductDto);
            if (isSaved == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }
            return ApiResponseDto<bool>.IsSuccess(isSaved);
        }

        [HttpPut]
        public async Task<ApiResponseDto<bool>> UpdateProduct( [FromBody] UpdateProductDto updateProductDto)
        {
            var isUpdated = await _productAppService.UpdateProductAsync( updateProductDto);
            if (isUpdated == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }

            return ApiResponseDto<bool>.IsSuccess(isUpdated);
        }   

        [HttpDelete("{id}")]
        public async Task<ApiResponseDto<bool>> DeleteProduct(int id)
        {
            var isDeleted = await _productAppService.DeleteProductAsync(id);

            if (isDeleted == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }
            return ApiResponseDto<bool>.IsSuccess(isDeleted);
        }

        [HttpGet]
        public async Task<ApiResponseDto<List<ProductInfo>>> ProductsToReorderAsync()
        {
            var products = await _productAppService.GetProductsToReorderAsync();
            return ApiResponseDto<List<ProductInfo>>.IsSuccess(products);
        }
        [HttpGet]
        public async Task<ApiResponseDto<List<ProductInfo>>> ProductsWithMinimumOrdersAsync()
        {
            var products = await _productAppService.GetProductsWithMinimumOrdersAsync();
            return ApiResponseDto<List<ProductInfo>>.IsSuccess(products);
        }
    }
}
