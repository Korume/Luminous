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
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProductController> _logger;
        private readonly ProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productDtos = await _productRepository.GetAsync();

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