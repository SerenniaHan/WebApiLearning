using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Blazor.Models;

public record ShopInventory
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Item name is required")]
    public required string ItemName { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public required int Quantity { get; set; }
    public static ShopInventory Empty => new() { ItemName = string.Empty, Quantity = 0 };
}
