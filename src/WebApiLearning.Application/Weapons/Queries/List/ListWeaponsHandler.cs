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
            var response = await repository.GetAllAsync(cancellationToken);

            return new Result<IReadOnlyCollection<WeaponDto>>(
                response.Select(x => x.ToDto()).ToArray()
            );
        }
        catch (Exception e)
        {
            return new Result<IReadOnlyCollection<WeaponDto>>(e);
        }
    }
}
