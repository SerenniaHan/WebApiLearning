using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Inventories.Commands.CreateInventory;

public record CreateInventoryRequest(Guid ShopId, Guid ItemId, int Quantity)
    : IRequest<Result<Inventory>>;
