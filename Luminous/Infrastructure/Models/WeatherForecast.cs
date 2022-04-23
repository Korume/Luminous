using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Luminous.Infrastructure.Models
{
    public class WeatherForecast
    {
        [BsonId]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? WeatherForecastName { get; set; }
    }
}
