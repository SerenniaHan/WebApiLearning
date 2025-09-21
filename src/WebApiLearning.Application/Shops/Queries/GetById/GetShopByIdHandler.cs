using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Queries.GetById;

internal class GetShopByIdHandler(IShopRepository repository)
    : IRequestHandler<GetShopByIdQuery, Result<Option<ShopDto>>>
{
    public async Task<Result<Option<ShopDto>>> Handle(
        GetShopByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var response = await repository.GetByIdAsync(query.Id, cancellationToken);
            return new Result<Option<ShopDto>>(Option<ShopDto>.Some(response.ToDto()));
        }
        catch (Exception e)
        {
            return new Result<Option<ShopDto>>(e);
        }
    }
}
