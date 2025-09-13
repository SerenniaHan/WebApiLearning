using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Inventories.Commands.CreateInventory;

internal class CreateInventoryRequestHandler(IInventoryRepository repository)
    : IRequestHandler<CreateInventoryRequest, Result<Inventory>>
{
    public async Task<Result<Inventory>> Handle(
        CreateInventoryRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var inventory = new Inventory(
                ShopId: request.ShopId,
                ItemId: request.ItemId,
                Quantity: request.Quantity
            );
            await repository.CreateInventoryAsync(inventory);
            return new Result<Inventory>(inventory);
        }
        catch (Exception e)
        {
            return new Result<Inventory>(e);
        }
    }
}
