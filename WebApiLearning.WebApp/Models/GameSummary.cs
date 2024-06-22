namespace WebApiLearning.WebApp.Models;

public class GameSummary
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Genre { get; set; }
    public required decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}