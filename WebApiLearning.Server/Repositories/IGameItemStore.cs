using WebApiLearning.Server.Models;

namespace WebApiLearning.Server.Repositories;

public interface IGameItemsRepository
{
    Task<IEnumerable<GameItem>> GetItemsAsync();
    Task<GameItem?> GetItemAsync(string id);
    Task CreateItemAsync(GameItem item);
    Task UpdateItemAsync(GameItem item);
    Task DeleteItemAsync(string id);
}