namespace WebApiLearning.Blazor.Models;

public record InventorySummary
{
    public string ItemName { get; set; } = string.Empty;
    public string ShopName { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
}
