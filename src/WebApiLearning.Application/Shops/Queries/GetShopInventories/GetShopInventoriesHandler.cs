using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dtos;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Queries.GetShopInventories;

internal class GetShopInventoriesHandler(
    IInventoryRepository inventoryRepository,
    IWeaponRepository weaponRepository
) : IRequestHandler<GetShopInventoriesQuery, Result<IReadOnlyCollection<ShopInventoryDto>>>
{
    public async Task<Result<IReadOnlyCollection<ShopInventoryDto>>> Handle(
        GetShopInventoriesQuery request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            // get inventories by shop id
            var inventories = await inventoryRepository.GetInventoriesByShopIdAsync(request.Id);
            if (inventories.Count == 0)
            {
                return new Result<IReadOnlyCollection<ShopInventoryDto>>([]);
            }

            var response = new List<ShopInventoryDto>();
            // get weapon names by weapon ids
            foreach (var inventory in inventories)
            {
                var weapon = await weaponRepository.GetByIdAsync(inventory.ItemId);
                response.Add(new ShopInventoryDto(weapon.Name, inventory.Quantity));
            }

            return new Result<IReadOnlyCollection<ShopInventoryDto>>(response);
        }
        catch (Exception e)
        {
            return new Result<IReadOnlyCollection<ShopInventoryDto>>(e);
        }
    }
}
