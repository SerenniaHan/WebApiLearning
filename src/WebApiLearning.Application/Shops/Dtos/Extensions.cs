using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Shops.Dtos;

public static class Extensions
{
    public static ShopDto ToDto(this Shop shop)
    {
        return new ShopDto(shop.Id, shop.Name, shop.Location);
    }
}
