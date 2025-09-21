using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Queries.GetById;

internal class GetWeaponByIdHandler(ICrudRepository<Weapon> repository)
    : IRequestHandler<GetWeaponByIdQuery, Result<Option<WeaponDto>>>
{
    public async Task<Result<Option<WeaponDto>>> Handle(
        GetWeaponByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var result = await repository.GetByIdAsync(query.Id, cancellationToken);
            return new Result<Option<WeaponDto>>(
                Option<WeaponDto>.Some(
                    new WeaponDto(
                        result.Id,
                        result.Name,
                        result.Rarity,
                        result.PurchasePrice,
                        result.SellPrice,
                        result.Damage,
                        result.AttackSpeed
                    )
                )
            );
        }
        catch (Exception e)
        {
            return new Result<Option<WeaponDto>>(e);
        }
    }
}
