using Luminous.Domain.Entities;
using Luminous.Infrastructure.Models;
using Luminous.Shared;

namespace Luminous.Server.Mappers
{
    public static class ProductMapper
    {
        public static ProductData ToData(Product product)
        {
            return new ProductData(null, product.Title, product.Price);
        }

        public static ProductData ToData(ProductDto productDto)
        {
            return new ProductData(null, productDto.Title!, productDto.Price!.Value, productDto.PhotoSources!);
        }

        public static Product ToDomain(ProductData productData)
        {
            return new Product(productData.Id, productData.Title, productData.Price);
        }

        public static Product ToDomain(ProductDto productDto)
        {
            return new Product(null, productDto.Title!, productDto.Price!.Value);
        }

        public static ProductDto ToDto(Product product)
        {
            return new ProductDto
            {
                Price = product.Price,
                Title = product.Title,
                PhotoSources = product.PhotoSources
            };
        }

        public static ProductDto ToDto(ProductData productData)
        {
            return new ProductDto
            {
                Price = productData.Price,
                Title = productData.Title,
                PhotoSources = productData.PhotoSources
            };
        }
    }
}
