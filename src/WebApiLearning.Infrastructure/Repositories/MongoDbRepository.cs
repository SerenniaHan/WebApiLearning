using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using WebApiLearning.Core.Entities;
using WebApiLearning.Core.Repository;

namespace WebApiLearning.Infrastructure.Repositories;

public class MongoDbRepository : IGameStoreRepository
{
    private readonly IMongoCollection<GameItem> _items;
    private readonly FilterDefinitionBuilder<GameItem> _filterBuilder = Builders<GameItem>.Filter;

    public MongoDbRepository(IMongoClient mongoClient, IConfiguration configuration)
    {
        var database = mongoClient.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
        _items = database.GetCollection<GameItem>(configuration["MongoDbSettings:CollectionName"]);
    }


    public Task CreateItemAsync(GameItem item)
    {
        return _items.InsertOneAsync(item);
    }

    public Task DeleteItemAsync(string id)
    {
        return _items.DeleteOneAsync(_filterBuilder.Eq(i => i.Id.ToString(), id));
    }

    public async Task<GameItem?> GetItemAsync(string id)
    {
        return await _items.Find(_filterBuilder.Eq(i => i.Id.ToString(), id)).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<GameItem>> GetItemsAsync()
    {
        return await _items.Find(new BsonDocument()).ToListAsync();
    }

    public Task UpdateItemAsync(GameItem item)
    {
        return _items.ReplaceOneAsync(_filterBuilder.Eq(i => i.Id.ToString(), item.Id.ToString()), item);
    }
}
