using MongoDB.Bson.Serialization.Attributes;

namespace WebApiLearning.Domain.Entities;

public record Weapon(
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice,
    int Damage,
    decimal AttackSpeed
) : IHasGuid
{
    [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = Name;

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public ERarity Rarity { get; set; } = Rarity;
    public int Damage { get; set; } = Damage;
    public decimal AttackSpeed { get; set; } = AttackSpeed;
    public int PurchasePrice { get; set; } = PurchasePrice;
    public int SellPrice { get; set; } = SellPrice;
}
