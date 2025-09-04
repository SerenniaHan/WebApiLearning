using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Get;

internal class GetWeaponByIdRequestHandler(IGameObjectRepository<Weapon> repository)
    : IRequestHandler<GetWeaponByIdRequest, Result<Option<Weapon>>>
{
    public async Task<Result<Option<Weapon>>> Handle(
        GetWeaponByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var result = await repository.GetGameObjectByIdAsync(request.Id);
            return new Result<Option<Weapon>>(Option<Weapon>.Some(result));
        }
        catch (Exception e)
        {
            return new Result<Option<Weapon>>(e);
        }
    }
}
