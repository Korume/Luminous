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
        public decimal Price { get; set; }

        public ProductData(string? id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}
