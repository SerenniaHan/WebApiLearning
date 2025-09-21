using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Commands.DeleteWeaponById;

internal class DeleteByIdRequestHandler(ICrudRepository<Weapon> repository)
    : IRequestHandler<DeleteByIdRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        DeleteByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await repository.DeleteByIdAsync(request.Id);
            return new Result<Guid>(request.Id);
        }
        catch (Exception e)
        {
            return new Result<Guid>(e);
        }
    }
}
