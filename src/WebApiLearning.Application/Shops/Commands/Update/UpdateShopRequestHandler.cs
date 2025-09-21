using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;
using WebApiLearning.Domain.Entities;
using WebApiLearning.Domain.Repository;

namespace WebApiLearning.Application.Shops.Commands.Update;

internal class UpdateShopRequestHandler(IShopRepository repository)
    : IRequestHandler<UpdateShopCommand, Result<ShopDto>>
{
    public async Task<Result<ShopDto>> Handle(
        UpdateShopCommand command,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var shop = new Shop(command.Name, command.Location) { Id = command.Id };

            await repository.UpdateAsync(shop, cancellationToken);

            return new Result<ShopDto>(shop.ToDto());
        }
        catch (Exception e)
        {
            return new Result<ShopDto>(e);
        }
    }
}
