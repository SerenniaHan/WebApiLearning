namespace WebApiLearning.Server.Models;

public record GameItem
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public double Price { get; init; }
}