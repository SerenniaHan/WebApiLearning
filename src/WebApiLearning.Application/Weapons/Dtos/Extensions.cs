using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Dtos;

public static class Extensions
{
    public static WeaponDto ToDto(this Weapon weapon)
    {
        return new WeaponDto(
            weapon.Id,
            weapon.Name,
            weapon.Rarity,
            weapon.PurchasePrice,
            weapon.SellPrice,
            weapon.Damage,
            weapon.AttackSpeed
        );
    }
}
