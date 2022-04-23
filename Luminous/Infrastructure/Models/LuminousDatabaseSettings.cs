namespace Luminous.Infrastructure.Models
{
    public class LuminousDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string WeatherForecastCollectionName { get; set; } = null!;

    }
}
