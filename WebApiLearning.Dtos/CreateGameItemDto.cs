using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Dtos;

public record CreateGameItemDto
{
    [Required]
    public string? Name { get; init; }
    [Range(1, 1000)]
    public double Price { get; init; }
}