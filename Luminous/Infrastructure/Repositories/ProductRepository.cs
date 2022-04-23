using Luminous.Infrastructure.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Luminous.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoCollection<ProductData> _productCollection;

        public ProductRepository(IOptions<LuminousMongoDbSettings> luminousDatabaseSettings)
        {
            var mongoClient = new MongoClient(luminousDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(luminousDatabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<ProductData>(luminousDatabaseSettings.Value.ProductCollectionName);
        }

        public async Task CreateAsync(ProductData newProduct) =>
            await _productCollection.InsertOneAsync(newProduct);

        public async Task<List<ProductData>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();
    }
}
