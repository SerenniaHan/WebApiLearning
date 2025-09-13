using MongoDB.Bson.Serialization.Attributes;

namespace WebApiLearning.Domain.Entities;

public record Inventory(Guid ShopId, Guid ItemId, int Quantity) : IHasGuid
{
    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid ShopId { get; set; } = ShopId;

    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid ItemId { get; set; } = ItemId;
    public int Quantity { get; set; } = Quantity;
}
