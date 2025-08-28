using System.ComponentModel.DataAnnotations;

namespace WebApiLearning.Contracts;

public record GameItemResponse(string Id, string? Name, double Price);
public record CreateGameItemRequest([Required] string? Name, [Range(1, 1000)] double Price);
public partial record UpdateGameItemRequest([Required] string? Name, [Range(1, 1000)] double Price);