using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Commands.UpdateShop;

internal class UpdateShopRequestHandler(IShopRepository repository)
    : IRequestHandler<UpdateShopRequest>
{
    public async Task Handle(UpdateShopRequest request, CancellationToken cancellationToken)
    {
        var shop = new Shop(request.Name, request.Location) with { Id = request.Id };

        await repository.UpdateShopAsync(shop);
    }
}
