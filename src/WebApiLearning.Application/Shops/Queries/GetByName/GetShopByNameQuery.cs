using LanguageExt;
using MediatR;
using WebApiLearning.Application.Shops.Dtos;

namespace WebApiLearning.Application.Shops.Queries.GetByName;

public sealed record GetShopByNameQuery(string Name) : IRequest<Option<ShopDto>>;
