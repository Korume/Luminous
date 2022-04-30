using Luminous.Infrastructure.Repositories;
using Luminous.Server.Mappers;
using Luminous.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Luminous.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productDatas = await _productRepository.GetAsync();

            var productDtos = productDatas.Select(p => ProductMapper.ToDto(p)).ToList();

            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            var productData = ProductMapper.ToData(productDto);

            await _productRepository.CreateAsync(productData);

            return Ok();
        }
    }
}