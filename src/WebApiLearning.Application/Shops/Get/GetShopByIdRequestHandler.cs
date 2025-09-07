using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Get;

internal class GetShopByIdRequestHandler(IShopRepository repository)
    : IRequestHandler<GetShopByIdRequest, Result<Option<Shop>>>
{
    public async Task<Result<Option<Shop>>> Handle(
        GetShopByIdRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var shop = await repository.GetByIdAsync(request.Id);
            return new Result<Option<Shop>>(Option<Shop>.Some(shop));
        }
        catch (Exception e)
        {
            return new Result<Option<Shop>>(e);
        }
    }
}
