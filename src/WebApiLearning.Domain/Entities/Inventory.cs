using MongoDB.Bson.Serialization.Attributes;

namespace WebApiLearning.Domain.Entities;

public record Inventory(Guid ShopId, Guid ItemId, int Quantity) : IHasGuid
{
    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ShopName { get; set; } = default!;
    public string ItemName { get; set; } = default!;
    public int Quantity { get; set; } = Quantity;
}
