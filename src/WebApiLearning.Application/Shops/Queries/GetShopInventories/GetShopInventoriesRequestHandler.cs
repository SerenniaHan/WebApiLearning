using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Queries.GetShopInventories;

public class GetShopInventoriesRequestHandler(
    IInventoryRepository inventoryRepository,
    ICrudRepository<Weapon> crudRepository
)
    : IRequestHandler<
        GetShopInventoriesRequest,
        Result<Option<IReadOnlyCollection<GetShopInventoriesResponse>>>
    >
{
    public async Task<Result<Option<IReadOnlyCollection<GetShopInventoriesResponse>>>> Handle(
        GetShopInventoriesRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var inventories = await inventoryRepository.GetInventoriesByShopIdAsync(request.Id);

            if (inventories is null || inventories.Count == 0)
            {
                return Option<IReadOnlyCollection<GetShopInventoriesResponse>>.None;
            }

            var response = inventories
                .Select(async inventory =>
                {
                    var item = await crudRepository.GetByIdAsync(inventory.ItemId);
                    return Option<GetShopInventoriesResponse>.Some(
                        new GetShopInventoriesResponse(inventory.Id, item.Name, inventory.Quantity)
                    );
                })
                .Select(task => task.Result)
                .Somes()
                .ToList();

            return new Result<Option<IReadOnlyCollection<GetShopInventoriesResponse>>>(
                Option<IReadOnlyCollection<GetShopInventoriesResponse>>.Some(response)
            );
        }
        catch (Exception e)
        {
            return new Result<Option<IReadOnlyCollection<GetShopInventoriesResponse>>>(e);
        }
    }
}
