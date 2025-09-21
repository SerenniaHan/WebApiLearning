using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Commands.Create;

internal class CreateShopHandler(IShopRepository repository)
    : IRequestHandler<CreateShopCommand, Result<ShopDto>>
{
    public async Task<Result<ShopDto>> Handle(
        CreateShopCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var shop = new Shop(command.Name, command.Location);
            await repository.CreateAsync(shop, cancellationToken);

            return new Result<ShopDto>(shop.ToDto());
        }
        catch (Exception e)
        {
            return new Result<ShopDto>(e);
        }
    }
}
