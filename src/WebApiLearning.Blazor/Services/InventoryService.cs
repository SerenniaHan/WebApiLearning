using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Services;

public class InventoryService(HttpClient httpClient)
{
    public Task<List<InventorySummary>?> AllInventories()
    {
        return httpClient.GetFromJsonAsync<List<InventorySummary>>("api/inventories");
    }
}
