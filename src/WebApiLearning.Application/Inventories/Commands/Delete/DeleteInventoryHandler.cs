using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Inventories.Commands.Delete;

internal class DeleteInventoryHandler(IInventoryRepository repository)
    : IRequestHandler<DeleteInventoryCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(
        DeleteInventoryCommand request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return await repository.DeleteByIdAsync(request.Id, cancellationToken);
        }
        catch (Exception e)
        {
            return new Result<bool>(e);
        }
    }
}
