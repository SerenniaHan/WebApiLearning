using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Blazor.Models;

public class WeaponDetails
{
    public Guid Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
    public required string Name { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Rarity is required.")]
    public EItemRarity Rarity { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Damage is required.")]
    [Range(
        0,
        int.MaxValue,
        ErrorMessage = "Damage must be a non-negative integer.",
        MinimumIsExclusive = true
    )]
    public int Damage { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Attack Speed is required.")]
    [Range(
        0,
        int.MaxValue,
        ErrorMessage = "Attack Speed mu st be a non-negative integer.",
        MinimumIsExclusive = true
    )]
    public decimal AttackSpeed { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Purchase Price is required.")]
    [Range(
        0,
        int.MaxValue,
        ErrorMessage = "Purchase Price must be a non-negative integer.",
        MinimumIsExclusive = true
    )]
    public int PurchasePrice { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Sell Price is required.")]
    [Range(
        0,
        int.MaxValue,
        ErrorMessage = "Sell Price must be a non-negative integer.",
        MinimumIsExclusive = true
    )]
    public int SellPrice { get; set; }

    public static WeaponDetails Empty =>
        new()
        {
            Name = string.Empty,
            Rarity = EItemRarity.Common,
            Damage = 0,
            AttackSpeed = 0m,
            PurchasePrice = 0,
            SellPrice = 0,
        };
}
