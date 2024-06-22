using MongoDB.Bson;
using MongoDB.Driver;
using WebApiLearning.Server.Models;

namespace WebApiLearning.Server.Repositories;

public class MongoDbRepository : IGameItemsRepository
{
    private const string DbName = "game";
    private const string CollectionName = "items";
    private readonly IMongoCollection<GameItem> _gameItems;
    private readonly FilterDefinitionBuilder<GameItem> _filterBuilder = Builders<GameItem>.Filter;

    public MongoDbRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(DbName);
        _gameItems = database.GetCollection<GameItem>(CollectionName);
    }
    
    public async Task<IEnumerable<GameItem>> GetItemsAsync()
    {
        return await _gameItems.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<GameItem?> GetItemAsync(string id)
    {
        return await _gameItems.Find(_filterBuilder.Eq(gi => gi.Id.ToString(), id)).SingleOrDefaultAsync();
    }

    public async Task CreateItemAsync(GameItem item)
    {
        await _gameItems.InsertOneAsync(item);
    }

    public async Task UpdateItemAsync(GameItem item)
    {
        await _gameItems.ReplaceOneAsync(_filterBuilder.Eq(gi => gi.Id, item.Id), item);
    }

    public async Task DeleteItemAsync(string id)
    {
        await _gameItems.DeleteOneAsync(_filterBuilder.Eq(gi => gi.Id.ToString(), id));
    }
}