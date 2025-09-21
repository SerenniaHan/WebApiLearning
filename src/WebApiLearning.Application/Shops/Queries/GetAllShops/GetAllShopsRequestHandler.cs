using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Queries.GetAllShops;

internal class GetAllShopsRequestHandler(IShopRepository repository)
    : IRequestHandler<GetAllShopsRequest, Result<IReadOnlyCollection<Shop>>>
{
    public async Task<Result<IReadOnlyCollection<Shop>>> Handle(
        GetAllShopsRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var shops = await repository.GetAllAsync();
            return new Result<IReadOnlyCollection<Shop>>(shops);
        }
        catch (Exception e)
        {
            return new Result<IReadOnlyCollection<Shop>>(e);
        }
    }
}
