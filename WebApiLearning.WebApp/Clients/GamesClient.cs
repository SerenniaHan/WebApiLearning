using WebApiLearning.WebApp.Models;

namespace WebApiLearning.WebApp.Clients;

public class GamesClient
{
    private readonly Genre[] _genres = new GenresClient().GetGenres();
    private readonly List<GameSummary> _gameSummaries =
    [
        new GameSummary
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Game 1",
            Genre = "Action",
            Price = 1.99M,
            ReleaseDate = DateOnly.FromDateTime(dateTime: DateTime.Now)
        },
        new GameSummary
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Game 2",
            Genre = "Adventure",
            Price = 2.99M,
            ReleaseDate = DateOnly.FromDateTime(dateTime: DateTime.Now)
        },
    ];
    
    
    public async Task<GameSummary[]> GetGamesAsync()
    {
        return await Task.FromResult(_gameSummaries.ToArray());
    }
    
    public async Task AddGameAsync(GameDetails gameDetails)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(gameDetails.GenreId);

        var genre = _genres.Single(g => g.Id == int.Parse(gameDetails.GenreId));
        _gameSummaries.Add(new GameSummary
        {
            Id = Guid.NewGuid().ToString(),
            Name = gameDetails.Name,
            Genre = genre.Name,
            Price = gameDetails.Price,
            ReleaseDate = gameDetails.ReleaseDate
        });
        
        await Task.CompletedTask;
    }
}