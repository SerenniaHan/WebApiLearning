using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Infrastructure.Mongo.Repositories;

public class InventoriesRepository : IInventoryRepository
{
    private readonly string _collectionName = "inventories";
    private readonly IMongoCollection<BsonDocument> _bsonCollection;

    public InventoriesRepository(IMongoDatabase mongoDatabase)
    {
        _bsonCollection = mongoDatabase.GetCollection<BsonDocument>(_collectionName);
    }

    public async Task<IReadOnlyCollection<Inventory>> GetInventoriesByShopIdAsync(
        Guid shopId,
        CancellationToken cancellationToken = default
    )
    {
        var documents = await _bsonCollection
            .Aggregate()
            .Match(new BsonDocument("ShopId", shopId.ToString()))
            .Lookup("shops", "ShopId", "_id", "shop")
            .Unwind("shop")
            .Lookup("game_items", "ItemId", "_id", "items")
            .Unwind("items")
            .Project(
                new BsonDocument
                {
                    { "_id", 0 },
                    { "Quantity", 1 },
                    { "ShopName", "$shop.Name" },
                    { "ItemName", "$items.Name" },
                }
            )
            .ToListAsync(cancellationToken);

        return [.. documents.Select(doc => BsonSerializer.Deserialize<Inventory>(doc))];
    }

    public async Task CreateAsync(
        Inventory entity,
        CancellationToken cancellationToken = default
    ) { }

    public async Task<Inventory> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        return await _collection
            .Find(_filterBuilder.Eq(i => i.Id, id))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Inventory>> GetAllAsync(
        CancellationToken cancellationToken = default
    )
    {
        var documents = await _bsonCollection
            .Aggregate()
            .Lookup("shops", "ShopId", "_id", "shop")
            .Unwind("shop")
            .Lookup("game_items", "ItemId", "_id", "items")
            .Unwind("items")
            .Project(
                new BsonDocument
                {
                    { "_id", 0 },
                    { "Quantity", 1 },
                    { "ShopName", "$shop.Name" },
                    { "ItemName", "$items.Name" },
                }
            )
            .ToListAsync(cancellationToken);

        return [.. documents.Select(doc => BsonSerializer.Deserialize<Inventory>(doc))];
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _collection.DeleteOneAsync(
            _filterBuilder.Eq(i => i.Id, id),
            cancellationToken
        );
        return result.DeletedCount > 0;
    }

    public async Task UpdateAsync(Inventory entity, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(
            _filterBuilder.Eq(i => i.Id, entity.Id),
            entity,
            cancellationToken: cancellationToken
        );
    }
}
