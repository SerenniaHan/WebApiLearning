using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Components.Pages.Inventories;

public partial class Inventories
{
    private List<InventorySummary>? inventories;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        inventories = await InventoryService.AllInventories();
    }
}
