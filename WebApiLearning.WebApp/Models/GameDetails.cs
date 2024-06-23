namespace WebApiLearning.WebApp.Models;

public class GameDetails
{
    public required string Name { get; set; }
    public string? GenreId { get; set; }
    public required decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}