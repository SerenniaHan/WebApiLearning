namespace WebApiLearning.Domain.Entities;

public record Inventory(Guid ShopId, Guid ItemId, int Quantity) : IHasGuid
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ShopId { get; set; } = ShopId;
    public Guid ItemId { get; set; } = ItemId;
    public int Quantity { get; set; } = Quantity;
}
