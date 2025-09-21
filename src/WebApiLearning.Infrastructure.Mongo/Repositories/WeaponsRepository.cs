using MongoDB.Bson;
using MongoDB.Driver;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Infrastructure.Mongo.Repositories;

public class WeaponsRepository : IWeaponRepository
{
    private readonly string _collectionName = "game_items";
    private readonly IMongoCollection<Weapon> _weapons;
    private readonly FilterDefinitionBuilder<Weapon> _filterBuilder = Builders<Weapon>.Filter;

    public WeaponsRepository(IMongoDatabase database)
    {
        _weapons = database.GetCollection<Weapon>(_collectionName);
    }

    public async Task CreateAsync(Weapon entity, CancellationToken cancellationToken = default)
    {
        await _weapons.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task<Weapon> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _weapons
            .Find(_filterBuilder.Eq(weapon => weapon.Id, id))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Weapon>> GetAllAsync(CancellationToken cancellationToken = default)
    {
         return await _weapons.Find(new BsonDocument()).ToListAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _weapons.DeleteOneAsync(_filterBuilder.Eq(weapon => weapon.Id, id), cancellationToken);
    }

    public async Task UpdateAsync(Weapon entity, CancellationToken cancellationToken = default)
    {
        await _weapons.ReplaceOneAsync(
            _filterBuilder.Eq(existingWeapon => existingWeapon.Id, entity.Id),
            entity,
            cancellationToken: cancellationToken
        );
    }
}
