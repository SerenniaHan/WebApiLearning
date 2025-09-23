using LanguageExt;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Queries.GetByName;

internal class GetWeaponByNameHandler(IWeaponRepository repository)
    : IRequestHandler<GetWeaponByNameQuery, Option<WeaponDto>>
{
    public Task<Option<WeaponDto>> Handle(
        GetWeaponByNameQuery request,
        CancellationToken cancellationToken
    )
    {
        return repository
            .GetByNameAsync(request.Name, cancellationToken)
            .Map(w => w == null ? Option<WeaponDto>.None : Option<WeaponDto>.Some(w.ToDto()));
    }
}
