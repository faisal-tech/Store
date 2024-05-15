using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contracts.Dtos;
using Store.Application.Contracts.Product;
using Store.Application.Contracts.Product.Dtos;
using Store.Domain.Dtos;
using Store.Domain.Entities;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
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

            return new ApiResponseDto<ProductDto>().IsSuccess(product);
        }

        [HttpPost("ProductsList")]
        public async Task<ApiResponseDto<List<ProductDto>>> ProductsList(SearchFilterDto request)
        {
            //throw new InvalidOperationException("This is a test exception.");
            var products = await _productAppService.GetAllProductsAsync(request);
            return new ApiResponseDto<List<ProductDto>>().IsSuccess(products);
        }

        [HttpPost]
        public async Task<ApiResponseDto<bool>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var isSaved = await _productAppService.CreateProductAsync(createProductDto);
            if (isSaved == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }
            return new ApiResponseDto<bool>().IsSuccess(isSaved);
        }   

        [HttpPut]
        public async Task<ApiResponseDto<bool>> UpdateProduct( [FromBody] UpdateProductDto updateProductDto)
        {
            var isUpdated = await _productAppService.UpdateProductAsync( updateProductDto);
            if (isUpdated == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }

            return new ApiResponseDto<bool>().IsSuccess(isUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponseDto<bool>> DeleteProduct(int id)
        {
            var isDeleted = await _productAppService.DeleteProductAsync(id);

            if (isDeleted == false)
            {
                throw new InvalidOperationException("Internal Server Error");
            }
            return new ApiResponseDto<bool>().IsSuccess(isDeleted);
        }
    }
}
