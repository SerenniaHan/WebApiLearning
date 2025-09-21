using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Domain.Repository;

public interface IShopRepository
{
    Task<Shop> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<Shop>> GetShopsAsync();
    Task CreateShopAsync(Shop shop);
    Task UpdateShopAsync(Shop shop);
    Task DeleteByIdAsync(Guid id);
}
