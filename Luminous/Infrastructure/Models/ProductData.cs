using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Luminous.Infrastructure.Models
{
    public class ProductData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; private set; }

        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement]
        [BsonRequired]
        public List<string> PhotoSources { get; private set; }

        public ProductData(string? id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
            PhotoSources = new List<string>();
        }

        public ProductData(string? id, string title, decimal price, List<string> photoSources)
        {
            Id = id;
            Title = title;
            Price = price;
            PhotoSources = photoSources;
        }
    }
}
