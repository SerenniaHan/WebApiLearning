using MediatR;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Commands.Delete;

public class DeleteShopHandler(IShopRepository repository) : IRequestHandler<DeleteShopCommand>
{
    public Task Handle(DeleteShopCommand command, CancellationToken cancellationToken)
    {
        return repository.DeleteByIdAsync(command.ShopId, cancellationToken);
    }
}
