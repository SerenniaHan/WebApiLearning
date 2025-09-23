using WebApiLearning.Blazor.Models;
using WebApiLearning.Blazor.Services;

namespace WebApiLearning.Blazor.Components.Pages.Shops;

public partial class Shops
{
    private List<ShopDetails>? shops;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        shops = await ShopService
            .AllShops()
            .ContinueWith(t =>
                t.Result?.Select(s => new ShopDetails
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Location = s.Location,
                    })
                    .ToList()
            );
    }

    private static string EditShopUrl(Guid shopId) => $"/shops/edit/{shopId}";
}
