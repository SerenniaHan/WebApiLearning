using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Contracts;

public record AllGameItemsResponse(IEnumerable<GameItemResponse> Items);
public record GameItemResponse(string Id, string? Name, double Price);
public record GetItemRequest([Required] Guid Id);
public record CreateGameItemRequest([Required] string? Name, [Range(1, 1000)] double Price);
public record UpdateGameItemRequest([Required] string? Name, [Range(1, 1000)] double Price);