namespace WebApiLearning.Blazor.Models;

public record ShopDetails
{
    public string Name { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
}
