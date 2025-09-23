using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Domain.Repository;

public interface IShopRepository : ICrudRepository<Shop>
{
    Task<Shop?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
