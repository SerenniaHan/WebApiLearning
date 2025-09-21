using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dtos;

namespace WebApiLearning.Application.Shops.Queries.List;

public record ListShopsQuery : IRequest<Result<IReadOnlyCollection<ShopDto>>>;
