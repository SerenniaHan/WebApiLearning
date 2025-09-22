using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Domain.Repository;

public interface IWeaponRepository : ICrudRepository<Weapon>
{
    Task<Weapon?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
