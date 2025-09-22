using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dtos;

namespace WebApiLearning.Application.Shops.Queries.GetShopInventories;

public record GetShopInventoriesQuery(Guid Id)
    : IRequest<Result<IReadOnlyCollection<ShopInventoryDto>>>;
