using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Weapons.Delete;

internal class DeleteByIdRequestHandler(IGameObjectRepository<Weapon> repository)
    : IRequestHandler<DeleteByIdRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        DeleteByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await repository.DeleteGameObjectAsync(request.Id);
            return new Result<Guid>(request.Id);
        }
        catch (Exception e)
        {
            return new Result<Guid>(e);
        }
    }
}
