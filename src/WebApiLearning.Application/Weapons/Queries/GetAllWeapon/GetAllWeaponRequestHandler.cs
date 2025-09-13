using LanguageExt;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Queries.GetAllWeapon;

internal class GetAllWeaponRequestHandler(IGameItemRepository<Weapon> repository)
    : IRequestHandler<GetAllWeaponRequest, Option<IReadOnlyCollection<Weapon>>>
{
    public async Task<Option<IReadOnlyCollection<Weapon>>> Handle(
        GetAllWeaponRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var weapons = await repository.GetAllGameObjectsAsync();
            return Option<IReadOnlyCollection<Weapon>>.Some(weapons);
        }
        catch (Exception)
        {
            return Option<IReadOnlyCollection<Weapon>>.None;
        }
    }
}
