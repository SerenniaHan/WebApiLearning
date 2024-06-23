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
            Genre = "Shooter",
            Price = 1.99M,
            ReleaseDate = DateOnly.FromDateTime(dateTime: DateTime.Now)
        },
        new GameSummary
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Game 2",
            Genre = "Racing",
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
        var genre = GetGenreById(gameDetails.GenreId);

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

    public async Task<GameDetails> GetGameAsync(string id)
    {
        var game = GetGameSummaryById(id);
        var genre = _genres.Single(g => string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase));
        return await Task.FromResult(new GameDetails()
        {
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        });
    }

    public async Task UpdateGameAsync(GameDetails updatedGame)
    {
        ArgumentNullException.ThrowIfNull(updatedGame.Id);
        var genre = GetGenreById(updatedGame.GenreId);
        var game = GetGameSummaryById(updatedGame.Id);
        game.Name = updatedGame.Name;
        game.Genre = genre.Name;
        game.Price = updatedGame.Price;
        game.ReleaseDate = updatedGame.ReleaseDate;
        await Task.CompletedTask;
    }

    private GameSummary GetGameSummaryById(string id)
    {
        var game = _gameSummaries.Find(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return _genres.Single(g => g.Id == int.Parse(id));
    }
}