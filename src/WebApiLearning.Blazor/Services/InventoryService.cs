using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Services;

public class InventoryService
{
    private readonly HttpClient _httpClient;

    public InventoryService(IConfiguration configuration)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(
                configuration.GetConnectionString("ApiServerUrl")
                    ?? throw new InvalidOperationException(
                        "Connection string 'ApiServerUrl' not found."
                    )
            ),
        };
    }

    public Task<List<InventorySummary>?> AllInventories()
    {
        return _httpClient.GetFromJsonAsync<List<InventorySummary>>("api/inventories");
    }
}
