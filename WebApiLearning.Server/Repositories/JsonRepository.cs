using WebApiLearning.Server.Models;

namespace WebApiLearning.Server.Repositories;

public class JsonRepository(IConfiguration configuration) : IGameItemsRepository
{
    private readonly List<GameItem> _gameItems = configuration.GetSection("GameItems").Get<List<GameItem>>() ??
                                                 throw new InvalidOperationException("GameItems not found in configuration");

    public Task<IEnumerable<GameItem>> GetItemsAsync()
    {
        return Task.FromResult(_gameItems.AsEnumerable());
    }

    public Task<GameItem?> GetItemAsync(string id)
    {
        return Task.FromResult(_gameItems.SingleOrDefault(x => x.Id.ToString() == id));
    }

    public Task CreateItemAsync(GameItem item)
    {
        _gameItems.Add(item);
        return Task.CompletedTask;
    }

    public Task UpdateItemAsync(GameItem item)
    {
        var existingItem = _gameItems.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem is null)
        {
            throw new InvalidOperationException("Item not found");
        }

        _gameItems.Remove(existingItem);
        _gameItems.Add(item);
        return Task.CompletedTask;
    }

    public Task DeleteItemAsync(string id)
    {
        _gameItems.RemoveAt(_gameItems.FindIndex(x => x.Id.ToString() == id));
        return Task.CompletedTask;
    }
}