using WebApiLearning.Dtos;
using WebApiLearning.Server.Models;

namespace WebApiLearning.Server.Mappers;

public static class GameItemMapper
{
    public static GameItemDto ToDto(this GameItem source) => new() { Id = source.Id, Name = source.Name, Price = source.Price };
    public static GameItem FromDto(this CreateGameItemDto dto) => new() { Id = Guid.NewGuid(), Name = dto.Name, Price = dto.Price };
}