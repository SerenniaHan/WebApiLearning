using Microsoft.AspNetCore.Components;
using WebApiLearning.Blazor.Models;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Components.Pages.Shops;

public partial class EditShop
{
    [Parameter]
    public Guid? ShopId { get; set; }

    [SupplyParameterFromForm]
    private ShopDetails? ShopDetails { get; set; }

    private string _title = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        if (ShopDetails is not null)
        {
            return;
        }

        if (ShopId is not null)
        {
            var shop = await ShopService.GetShopById(ShopId.Value);
            if (shop is not null)
            {
                ShopDetails = new ShopDetails { Name = shop.Name, Location = shop.Location };
                _title = $"Edit {ShopDetails.Name}";
            }
        }
        else
        {
            ShopDetails = new ShopDetails();
            _title = "New Shop";
        }
    }

    private async Task HandleSubmitAsync()
    {
        ArgumentNullException.ThrowIfNull(ShopDetails);
        if (ShopId is not null)
        {
            await ShopService.UpdateShop(ShopId.Value, ShopDetails);
        }
        else
        {
            await ShopService.AddNewShop(
                new Shop(Name: ShopDetails.Name, Location: ShopDetails.Location)
            );
        }
        Navigation.NavigateTo("/shops");
    }
}
