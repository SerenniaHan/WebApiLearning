using MongoDB.Bson;
using MongoDB.Driver;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Infrastructure.Mongo.Repositories;

public class InventoriesRepository : IInventoryRepository
{
    private readonly string _collectionName = "inventories";
    private readonly IMongoCollection<Inventory> _collection;
    private readonly FilterDefinitionBuilder<Inventory> _filterBuilder = Builders<Inventory>.Filter;

    public InventoriesRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Inventory>(_collectionName);
    }

    public Task CreateInventoryAsync(Inventory inventory)
    {
        return _collection.InsertOneAsync(inventory);
    }

    public async Task<IReadOnlyCollection<Inventory>> GetAllInventoriesAsync()
    {
        return await _collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<Inventory?> GetByInventoryIdAsync(Guid id)
    {
        return await _collection.Find(_filterBuilder.Eq(i => i.Id, id)).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<Inventory>> GetInventoriesByShopIdAsync(Guid shopId)
    {
        return await _collection.Find(_filterBuilder.Eq(i => i.ShopId, shopId)).ToListAsync();
    }
}
