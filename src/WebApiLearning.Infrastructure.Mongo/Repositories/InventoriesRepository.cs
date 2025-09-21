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

    public async Task<IReadOnlyCollection<Inventory>> GetInventoriesByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(_filterBuilder.Eq(i => i.ShopId, shopId)).ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Inventory entity, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task<Inventory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(_filterBuilder.Eq(i => i.Id, id)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Inventory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _collection.DeleteOneAsync(_filterBuilder.Eq(i => i.Id, id), cancellationToken);
    }

    public async Task UpdateAsync(Inventory entity, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(_filterBuilder.Eq(i => i.Id, entity.Id), entity, cancellationToken: cancellationToken);
    }
}
