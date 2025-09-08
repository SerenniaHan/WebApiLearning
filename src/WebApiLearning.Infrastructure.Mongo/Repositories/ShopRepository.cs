using MongoDB.Bson;
using MongoDB.Driver;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Infrastructure.Mongo.Repositories;

public class ShopRepository : IShopRepository
{
    private readonly string _collectionName = "shops";
    private readonly IMongoCollection<Shop> _collection;
    private readonly FilterDefinitionBuilder<Shop> _filterBuilder = Builders<Shop>.Filter;

    public ShopRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Shop>(_collectionName);
    }

    public async Task<Shop> GetByIdAsync(Guid id)
    {
        return await _collection.Find(_filterBuilder.Eq(shop => shop.Id, id)).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<Shop>> GetShopsAsync()
    {
        var shops = await _collection.Find(new BsonDocument()).ToListAsync();
        return shops;
    }

    public async Task CreateShopAsync(Shop shop)
    {
        await _collection.InsertOneAsync(shop);
    }
}
