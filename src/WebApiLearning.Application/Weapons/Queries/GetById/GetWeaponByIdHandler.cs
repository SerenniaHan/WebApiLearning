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
            var response = await repository.GetByIdAsync(query.Id, cancellationToken);
            return new Result<Option<WeaponDto>>(Option<WeaponDto>.Some(response.ToDto()));
        }
        catch (Exception e)
        {
            return new Result<Option<WeaponDto>>(e);
        }
    }
}
