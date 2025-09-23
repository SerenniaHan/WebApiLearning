using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Blazor.Models;

public record ShopDetails
{
    public Guid Id { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false, ErrorMessage = "Location is required.")]
    public string Location { get; set; } = string.Empty;
}
