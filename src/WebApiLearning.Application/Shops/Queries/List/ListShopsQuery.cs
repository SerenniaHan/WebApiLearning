using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;

namespace WebApiLearning.Application.Shops.Queries.List;

public record ListShopsQuery : IRequest<Result<IReadOnlyCollection<ShopDto>>>;
