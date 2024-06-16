namespace WebApiLearning.Dtos;

public record GameItemDto 
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public double Price { get; init; }
}