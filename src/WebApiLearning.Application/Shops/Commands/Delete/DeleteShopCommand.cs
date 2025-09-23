using LanguageExt.Common;
using MediatR;

namespace WebApiLearning.Application.Shops.Commands.Delete;

public record DeleteShopCommand(Guid ShopId) : IRequest<Result<bool>>;
