using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.Update;

internal class UpdateWeaponHandler(ICrudRepository<Weapon> repository)
    : IRequestHandler<UpdateWeaponCommand, Result<WeaponDto>>
{
    public async Task<Result<WeaponDto>> Handle(
        UpdateWeaponCommand weaponCommand,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var weapon = new Weapon(
                weaponCommand.Name,
                weaponCommand.Rarity,
                weaponCommand.PurchasePrice,
                weaponCommand.SellPrice,
                weaponCommand.Damage,
                weaponCommand.AttackSpeed
            )
            {
                Id = weaponCommand.Id,
            };

            await repository.UpdateAsync(weapon, cancellationToken);
            return new Result<WeaponDto>(weapon.ToDto());
        }
        catch (Exception e)
        {
            return new Result<WeaponDto>(e);
        }
    }
}
