using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Contract.Product;
using Store.Application.Contract.Product.Dtos;
using Store.Application.Contracts.Dtos;
using Store.Application.Contracts.Dtos.Statistics;
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
            var response = await _productAppService.GetProductByIdAsync(id);
            if (response == null)
                throw new InvalidOperationException("Product was not found");

			return response;
        }

        [HttpGet]
        public async Task<ApiResponseDto<PagingDto<ProductDto>>> ProductsList([FromQuery]SearchFilterDto request)
        {
            var response = await _productAppService.GetAllProductsAsync(request);
            return response;
        }

        [HttpPost]
        public async Task<ApiResponseDto<bool>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var response = await _productAppService.CreateProductAsync(createProductDto);
            
            return response;
        }

        [HttpPut]
        public async Task<ApiResponseDto<bool>> UpdateProduct( [FromBody] UpdateProductDto updateProductDto)
        {
            var response = await _productAppService.UpdateProductAsync( updateProductDto);
           
            return response;
        }   

        [HttpDelete("{id}")]
        public async Task<ApiResponseDto<bool>> DeleteProduct(int id)
        {
            var response = await _productAppService.DeleteProductAsync(id);

            return response;
        }

        [HttpGet]
        public async Task<ApiResponseDto<List<ProductInfo>>> ProductsToReorderAsync()
        {
            var response = await _productAppService.GetProductsToReorderAsync();
            return response;
        }
        [HttpGet]
        public async Task<ApiResponseDto<List<ProductInfo>>> ProductsWithMinimumOrdersAsync()
        {
            var response = await _productAppService.GetProductsWithMinimumOrdersAsync();
            return response;
        }
    }
}
