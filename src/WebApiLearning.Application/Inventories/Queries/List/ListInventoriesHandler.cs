using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Inventories.Dtos;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Inventories.Queries.List;

internal class ListInventoriesHandler(
    IInventoryRepository inventoryRepository,
    IWeaponRepository weaponRepository,
    IShopRepository shopRepository
) : IRequestHandler<ListInventoriesQuery, Result<Option<IReadOnlyCollection<InventorySummaryDto>>>>
{
    public async Task<Result<Option<IReadOnlyCollection<InventorySummaryDto>>>> Handle(
        ListInventoriesQuery request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var summary = new List<InventorySummaryDto>();
            var inventories = await inventoryRepository.GetAllAsync(cancellationToken);

            foreach (var inventory in inventories)
            {
                var shop = await shopRepository.GetByIdAsync(inventory.ShopId, cancellationToken);
                var weapon = await weaponRepository.GetByIdAsync(
                    inventory.ItemId,
                    cancellationToken
                );

                if (shop is null || weapon is null)
                    throw new Exception("Related entity not found");

                summary.Add(new InventorySummaryDto(weapon.Name, inventory.Quantity, shop.Name));
            }

            return new Result<Option<IReadOnlyCollection<InventorySummaryDto>>>(summary);
        }
        catch (Exception e)
        {
            return new Result<Option<IReadOnlyCollection<InventorySummaryDto>>>(e);
        }
    }
}
