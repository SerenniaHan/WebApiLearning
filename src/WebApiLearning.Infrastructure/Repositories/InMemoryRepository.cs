using WebApiLearning.Core.Entities;
using WebApiLearning.Core.Repository;

namespace WebApiLearning.Infrastructure.Repositories;

public sealed class InMemoryRepository : IGameStoreRepository
{
    private readonly List<GameItem> _items = [];

    public Task CreateItemAsync(GameItem item)
    {
        _items.Add(item);
        return Task.CompletedTask;
    }

    public Task DeleteItemAsync(string id)
    {
        _items.RemoveAll(item => item.Id.ToString() == id);
        return Task.CompletedTask;
    }

    public Task<GameItem?> GetItemAsync(string id)
    {
        var item = _items.SingleOrDefault(item => item.Id.ToString() == id);
        return Task.FromResult(item);
    }

    public Task<IEnumerable<GameItem>> GetItemsAsync()
    {
        return Task.FromResult<IEnumerable<GameItem>>(_items);
    }

    public Task UpdateItemAsync(GameItem item)
    {
        var index = _items.FindIndex(i => i.Id == item.Id);
        if (index != -1)
        {
            _items[index] = item;
        }
        return Task.CompletedTask;
    }
}