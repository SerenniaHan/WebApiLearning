using WebApiLearning.WebApp.Models;

namespace WebApiLearning.WebApp.Clients;

public class GenresClient
{
    private readonly Genre[] _genres = new[]
    {
        new Genre { Id = 1, Name = "Fighting" },
        new Genre { Id = 2, Name = "Shooter" },
        new Genre { Id = 3, Name = "Racing" },
        new Genre { Id = 4, Name = "Sports" },
    };
    
    public Genre[] GetGenres() => _genres;
}