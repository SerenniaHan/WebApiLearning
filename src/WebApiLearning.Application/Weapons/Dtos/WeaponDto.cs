using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Dtos;

public sealed record WeaponDto(
    Guid Id,
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice,
    int Damage,
    decimal AttackSpeed
);
