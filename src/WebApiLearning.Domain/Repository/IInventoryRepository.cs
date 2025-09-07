using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Domain.Repository;

public interface IInventoryRepository
{
    Task CreateInventoryAsync(Inventory inventory);
    Task<IReadOnlyCollection<Inventory>> GetAllInventoriesAsync();
    Task<Inventory?> GetByInventoryIdAsync(Guid id);
    Task<IReadOnlyCollection<Inventory>> GetInventoriesByShopIdAsync(Guid shopId);
}
