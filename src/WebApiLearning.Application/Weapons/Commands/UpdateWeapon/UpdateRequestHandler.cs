using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.UpdateWeapon;

internal class UpdateRequestHandler(ICrudRepository<Weapon> repository)
    : IRequestHandler<UpdateCommand>
{
    public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var weapon = new Weapon(
            request.Name,
            request.Rarity,
            request.PurchasePrice,
            request.SellPrice,
            request.Damage,
            request.AttackSpeed
        ) with
        {
            Id = request.Id,
        };

        await repository.UpdateAsync(weapon);
    }
}
