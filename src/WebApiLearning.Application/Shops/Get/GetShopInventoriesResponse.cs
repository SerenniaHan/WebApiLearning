namespace WebApiLearning.Application.Shops.Get;

public record GetShopInventoriesResponse(Guid InventoryId, string ItemName, int Quantity);
