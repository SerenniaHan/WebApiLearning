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

    public async Task<Shop> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(_filterBuilder.Eq(shop => shop.Id, id)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Shop>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var shops = await _collection.Find(new BsonDocument()).ToListAsync(cancellationToken);
        return shops;
    }

    public async Task CreateAsync(Shop shop, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(shop, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(Shop shop, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(
            _filterBuilder.Eq(existingShop => existingShop.Id, shop.Id),
            shop,
            cancellationToken: cancellationToken
        );
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _collection.DeleteOneAsync(_filterBuilder.Eq(shop => shop.Id, id), cancellationToken);
    }
}
