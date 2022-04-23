using Luminous.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Luminous.Infrastructure.Commands
{
    public class WeatherForecastCreateCommand
    {
        private readonly IMongoCollection<WeatherForecast> _weatherForecastCollection;

        public WeatherForecastCreateCommand(IOptions<LuminousDatabaseSettings> luminousDatabaseSettings)
        {
            var mongoClient = new MongoClient(luminousDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(luminousDatabaseSettings.Value.DatabaseName);

            _weatherForecastCollection = mongoDatabase.GetCollection<WeatherForecast>(luminousDatabaseSettings.Value.WeatherForecastCollectionName);
        }

        public async Task CreateAsync(WeatherForecast newWeatherForecast) =>
            await _weatherForecastCollection.InsertOneAsync(newWeatherForecast);
    }
}