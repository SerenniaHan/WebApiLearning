using MongoDB.Bson;
using MongoDB.Driver;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Infrastructure.Mongo.Repositories;

public class WeaponsRepository : IGameObjectRepository<Weapon>
{
    private readonly string _collectionName = "Weapons";
    private readonly IMongoCollection<Weapon> _weapons;
    private readonly FilterDefinitionBuilder<Weapon> _filterBuilder = Builders<Weapon>.Filter;

    public WeaponsRepository(IMongoDatabase database)
    {
        _weapons = database.GetCollection<Weapon>(_collectionName);
    }

    public async Task CreateGameObjectAsync(Weapon gameObject)
    {
        await _weapons.InsertOneAsync(gameObject);
    }

    public async Task<Weapon> GetGameObjectByIdAsync(Guid id)
    {
        return await _weapons
            .Find(_filterBuilder.Eq(weapon => weapon.Id, id))
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<Weapon>> GetAllGameObjectsAsync()
    {
        var weapons = await _weapons.Find(new BsonDocument()).ToListAsync();
        return weapons;
    }

    public async Task DeleteGameObjectAsync(Guid id)
    {
        await _weapons.DeleteOneAsync(_filterBuilder.Eq(weapon => weapon.Id, id));
    }

    public async Task UpdateGameObjectAsync(Weapon gameObject)
    {
        await _weapons.ReplaceOneAsync(
            _filterBuilder.Eq(existingWeapon => existingWeapon.Id, gameObject.Id),
            gameObject
        );
    }
}
