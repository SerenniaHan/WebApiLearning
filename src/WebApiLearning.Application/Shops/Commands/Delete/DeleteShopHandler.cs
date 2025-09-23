using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Commands.Delete;

public class DeleteShopHandler(IShopRepository repository)
    : IRequestHandler<DeleteShopCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(
        DeleteShopCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return await repository.DeleteByIdAsync(command.ShopId, cancellationToken);
        }
        catch (Exception e)
        {
            return new Result<bool>(e);
        }
    }
}
