using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Inventories.Dtos;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Inventories.Commands.Create;

internal class CreateInventoryHandler(
    IInventoryRepository repository,
    IShopRepository shopRepository,
    IWeaponRepository itemRepository
) : IRequestHandler<CreateInventoryCommand, Result<InventoryDto>>
{
    public async Task<Result<InventoryDto>> Handle(
        CreateInventoryCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var shop = await shopRepository.GetByNameAsync(command.ShopName, cancellationToken);
            if (shop is null)
                return new Result<InventoryDto>(new Exception("Shop not found"));

            var item = await itemRepository.GetByNameAsync(command.ItemName, cancellationToken);
            if (item is null)
                return new Result<InventoryDto>(new Exception("Item not found"));

            var inventory = new Inventory(
                ShopId: shop.Id,
                ItemId: item.Id,
                Quantity: command.Quantity
            );
            await repository.CreateAsync(inventory, cancellationToken);
            return new Result<InventoryDto>(inventory.ToDto());
        }
        catch (Exception e)
        {
            return new Result<InventoryDto>(e);
        }
    }
}
