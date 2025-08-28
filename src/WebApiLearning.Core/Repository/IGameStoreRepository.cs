using WebApiLearning.Core.Entities;

namespace WebApiLearning.Core.Repository;

/// <summary>
/// Defines the contract for CRUD operations on game items in the store.
/// </summary>
public interface IGameStoreRepository
{
    /// <summary>
    /// Retrieves all game items from the store.
    /// </summary>
    /// <returns>A collection of <see cref="GameItem"/> objects.</returns>
    Task<IEnumerable<GameItem>> GetItemsAsync();

    /// <summary>
    /// Retrieves a single game item by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the game item.</param>
    /// <returns>The <see cref="GameItem"/> if found; otherwise, null.</returns>
    Task<GameItem?> GetItemAsync(string id);

    /// <summary>
    /// Creates a new game item in the store.
    /// </summary>
    /// <param name="item">The game item to create.</param>
    Task CreateItemAsync(GameItem item);

    /// <summary>
    /// Updates an existing game item in the store.
    /// </summary>
    /// <param name="item">The game item with updated information.</param>
    Task UpdateItemAsync(GameItem item);

    /// <summary>
    /// Deletes a game item from the store by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the game item to delete.</param>
    Task DeleteItemAsync(string id);
}
