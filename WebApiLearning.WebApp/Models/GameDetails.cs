using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.WebApp.Models;

public class GameDetails
{
    public string? Id { get; set; }
    [Required] 
    [StringLength(50)]
    public required string Name { get; set; }

    [Required(ErrorMessage = "The genre field is required.")] 
    public string? GenreId { get; set; }
    
    [Range(1, 100000)]
    public required decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}