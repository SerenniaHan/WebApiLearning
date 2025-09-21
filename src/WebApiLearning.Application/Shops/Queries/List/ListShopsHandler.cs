using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Queries.List;

internal class ListShopsHandler(IShopRepository repository)
    : IRequestHandler<ListShopsQuery, Result<IReadOnlyCollection<ShopDto>>>
{
    public async Task<Result<IReadOnlyCollection<ShopDto>>> Handle(
        ListShopsQuery query,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var response = await repository.GetAllAsync(cancellationToken);
            return new Result<IReadOnlyCollection<ShopDto>>(
                response.Select(shop => shop.ToDto()).ToArray()
            );
        }
        catch (Exception e)
        {
            return new Result<IReadOnlyCollection<ShopDto>>(e);
        }
    }
}
