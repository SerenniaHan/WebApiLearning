namespace WebApiLearning.Domain.Entities;

public record Weapon(
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice,
    int Damage,
    float AttackSpeed
) : IHasGuid
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = Name;
    public ERarity Rarity { get; set; } = Rarity;
    public int Damage { get; set; } = Damage;
    public float AttackSpeed { get; set; } = AttackSpeed;
    public int PurchasePrice { get; set; } = PurchasePrice;
    public int SellPrice { get; set; } = SellPrice;
}
