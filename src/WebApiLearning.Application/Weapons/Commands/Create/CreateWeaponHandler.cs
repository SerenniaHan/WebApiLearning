using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.Create;

internal class CreateWeaponHandler(IWeaponRepository repository)
    : IRequestHandler<CreateWeaponCommand, Result<WeaponDto>>
{
    public async Task<Result<WeaponDto>> Handle(
        CreateWeaponCommand weaponCommand,
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
            );
            await repository.CreateAsync(weapon, cancellationToken);

            return new Result<WeaponDto>(weapon.ToDto());
        }
        catch (Exception e)
        {
            return new Result<WeaponDto>(e);
        }
    }
}
