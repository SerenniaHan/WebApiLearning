namespace WebApiLearning.Domain.Entities;

public record Weapon : GameObject
{
    public int Damage { get; set; }
    public float AttackSpeed { get; set; }

    public Weapon(
        string name,
        ERarity rarity,
        int purchasePrice,
        int sellPrice,
        int damage,
        float attackSpeed
    )
        : base(name, rarity, purchasePrice, sellPrice)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
    }
}
