namespace WebApiLearning.Application.Inventories.Dtos;

public sealed record InventorySummaryDto(string ItemName, int Quantity, string ShopName);
