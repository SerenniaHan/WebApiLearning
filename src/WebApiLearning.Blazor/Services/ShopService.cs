using WebApiLearning.Blazor.Models;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Services;

public class ShopService
{
    private readonly HttpClient _httpClient;

    public ShopService(IConfiguration configuration)
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

    public Task<List<Shop>?> AllShops()
    {
        return _httpClient.GetFromJsonAsync<List<Shop>>("api/shops");
    }

    public Task<bool> AddNewShop(Shop shop)
    {
        var response = _httpClient.PostAsJsonAsync("api/shops", shop);
        return response.ContinueWith(t => t.Result.IsSuccessStatusCode);
    }

    public Task<Shop?> GetShopById(Guid id)
    {
        return _httpClient.GetFromJsonAsync<Shop?>($"api/shops/{id}");
    }

    public Task UpdateShop(Guid id, ShopDetails shopDetails)
    {
        var response = _httpClient.PutAsJsonAsync($"api/shops/{id}", shopDetails);
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }

    public Task DeleteShopAsync(Guid id)
    {
        var response = _httpClient.DeleteAsync($"api/shops/{id}");
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }
}
