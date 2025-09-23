using LanguageExt;
using MediatR;
using WebApiLearning.Application.Shops.Dtos;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Queries.GetByName;

internal class GetShopByNameHandler(IShopRepository repository)
    : IRequestHandler<GetShopByNameQuery, Option<ShopDto>>
{
    public Task<Option<ShopDto>> Handle(
        GetShopByNameQuery request,
        CancellationToken cancellationToken
    )
    {
        return repository
            .GetByNameAsync(request.Name, cancellationToken)
            .Map(shop => shop == null ? Option<ShopDto>.None : Option<ShopDto>.Some(shop.ToDto()));
    }
}
