using Microsoft.AspNetCore.Components;
using WebApiLearning.Blazor.Models;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Components.Pages.Shops;

public partial class DeleteShop
{
    [Parameter]
    public ShopDetails? Shop { get; set; }

    private string _title = string.Empty;

    protected override Task OnParametersSetAsync()
    {
        _title = $"Delete {Shop?.Name} ?";
        return base.OnParametersSetAsync();
    }

    public static string GetModalId(ShopDetails? shop)
    {
        ArgumentNullException.ThrowIfNull(shop);
        return $"deleteShopModal{shop.Id.ToString().Replace("-", string.Empty)}";
    }

    private async Task DeleteShopAsync()
    {
        if (Shop == null)
        {
            return;
        }

        await ShopService.DeleteShopAsync(Shop.Id);
        NavigationManager.Refresh();
    }
}
