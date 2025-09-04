using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Domain.Repository;

public interface IGameObjectRepository<T>
    where T : IGameObject
{
    Task CreateGameObjectAsync(T gameObject);
    Task<T> GetGameObjectByIdAsync(Guid id);
    Task<IReadOnlyCollection<T>> GetAllGameObjectsAsync();
    Task DeleteGameObjectAsync(Guid id);
    Task UpdateGameObjectAsync(T gameObject);
}
