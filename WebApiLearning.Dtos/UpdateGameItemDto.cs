using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Dtos;

public record UpdateGameItemDto
{
    [Required]
    public string? Name { get; init; }
    [Range(1, 1000)]
    public double Price { get; init; }
}