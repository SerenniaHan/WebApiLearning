using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.CreateWeapon;

internal class CreateWeaponRequestHandler(IGameItemRepository<Weapon> repository)
    : IRequestHandler<CreateWeaponRequest, Result<Weapon>>
{
    public async Task<Result<Weapon>> Handle(
        CreateWeaponRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var weapon = new Weapon(
                request.Name,
                request.Rarity,
                request.PurchasePrice,
                request.SellPrice,
                request.Damage,
                request.AttackSpeed
            );
            await repository.CreateGameObjectAsync(weapon);

            return new Result<Weapon>(weapon);
        }
        catch (Exception e)
        {
            return new Result<Weapon>(e);
        }
    }
}
