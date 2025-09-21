using MediatR;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Commands.DeleteShop;

public class DeleteShopRequestHandler(IShopRepository repository)
    : IRequestHandler<DeleteShopRequest>
{
    public Task Handle(DeleteShopRequest request, CancellationToken cancellationToken)
    {
        return repository.DeleteByIdAsync(request.ShopId);
    }
}
