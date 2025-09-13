namespace WebApiLearning.Application.Shops.Queries.GetShopInventories;

public record GetShopInventoriesResponse(Guid InventoryId, string ItemName, int Quantity);
