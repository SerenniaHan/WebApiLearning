using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;

namespace WebApiLearning.Application.Shops.Queries.GetById;

public record GetShopByIdQuery(Guid Id) : IRequest<Result<Option<ShopDto>>>;
