using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Inventories.Dtos;

namespace WebApiLearning.Application.Inventories.Commands.Create;

public record CreateInventoryCommand(string ShopName, string ItemName, int Quantity)
    : IRequest<Result<InventoryDto>>;
