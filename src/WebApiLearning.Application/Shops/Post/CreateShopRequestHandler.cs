using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Post;

internal class CreateShopRequestHandler(IShopRepository repository)
    : IRequestHandler<CreateShopRequest, Result<Shop>>
{
    public async Task<Result<Shop>> Handle(
        CreateShopRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var shop = new Shop(request.Name, request.Location);
            await repository.CreateShopAsync(shop);

            return new Result<Shop>(shop);
        }
        catch (Exception e)
        {
            return new Result<Shop>(e);
        }
    }
}
