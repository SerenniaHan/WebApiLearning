using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Blazor.Models;

public record ShopDetails
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Location is required.")]
    public string Location { get; set; } = string.Empty;
}
