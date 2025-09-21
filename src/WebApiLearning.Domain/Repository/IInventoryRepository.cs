using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Domain.Repository;

public interface IInventoryRepository : ICrudRepository<Inventory>
{
    Task<IReadOnlyCollection<Inventory>> GetInventoriesByShopIdAsync(Guid shopId, CancellationToken cancellationToken = default);
}
