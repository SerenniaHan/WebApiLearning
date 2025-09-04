using System.Runtime.Serialization;

namespace WebApiLearning.Domain.Entities;

public interface IGameObject
{
    Guid Id { get; set; }
    string Name { get; set; }
    ERarity Rarity { get; set; }
    int PurchasePrice { get; set; }
    int SellPrice { get; set; }
}

public abstract record GameObject(
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice) : IGameObject
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = Name;
    public ERarity Rarity { get; set; } = Rarity;
    public int PurchasePrice { get; set; } = PurchasePrice;
    public int SellPrice { get; set; } = SellPrice;
}