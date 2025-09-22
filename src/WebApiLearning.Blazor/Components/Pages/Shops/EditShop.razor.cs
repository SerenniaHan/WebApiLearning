using Microsoft.AspNetCore.Components;
using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Components.Pages.Shops;

public partial class EditShop
{
    [Parameter]
    public Guid? ShopId { get; set; }

    [SupplyParameterFromForm]
    private ShopDetails? ShopDetails { get; set; }

    private List<ShopInventory>? ShopInventories { get; set; } = [];

    private string _title = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        if (ShopDetails is not null)
        {
            return;
        }

        if (ShopId is not null)
        {
            ShopDetails = await ShopService.GetShopById(ShopId.Value);
            if (ShopDetails is not null)
            {
                ShopInventories = await ShopService.GetShopInventories(ShopId.Value);
            }
        }
        else
        {
            ShopDetails = new ShopDetails();
            ShopInventories = [];
        }
        _title = ShopId is not null ? $"Edit Shop - {ShopDetails!.Name}" : "New Shop";
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
                new ShopDetails { Name = ShopDetails.Name, Location = ShopDetails.Location }
            );
        }
        Navigation.NavigateTo("/shops");
    }
}
