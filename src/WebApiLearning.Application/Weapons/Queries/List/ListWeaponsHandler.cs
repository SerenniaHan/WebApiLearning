using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Queries.List;

internal class ListWeaponsHandler(ICrudRepository<Weapon> repository)
    : IRequestHandler<ListWeaponsQuery, Result<IReadOnlyCollection<WeaponDto>>>
{
    public async Task<Result<IReadOnlyCollection<WeaponDto>>> Handle(
        ListWeaponsQuery request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var weapons = (await repository.GetAllAsync(cancellationToken))
                .Select(x => new WeaponDto(
                    x.Id,
                    x.Name,
                    x.Rarity,
                    x.PurchasePrice,
                    x.SellPrice,
                    x.Damage,
                    x.AttackSpeed
                ))
                .ToArray();
            return new Result<IReadOnlyCollection<WeaponDto>>(weapons);
        }
        catch (Exception e)
        {
            return new Result<IReadOnlyCollection<WeaponDto>>(e);
        }
    }
}
