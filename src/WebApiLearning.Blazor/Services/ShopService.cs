using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Services;

public class ShopService(HttpClient httpClient)
{
    public Task<List<ShopDetails>?> AllShops()
    {
        return httpClient.GetFromJsonAsync<List<ShopDetails>>("api/shops");
    }

    public Task<bool> AddNewShop(ShopDetails shop)
    {
        var response = httpClient.PostAsJsonAsync("api/shops", shop);
        return response.ContinueWith(t => t.Result.IsSuccessStatusCode);
    }

    public Task<ShopDetails?> GetShopById(Guid id)
    {
        return httpClient.GetFromJsonAsync<ShopDetails?>($"api/shops/{id}");
    }

    public Task UpdateShop(Guid id, ShopDetails shopDetails)
    {
        var response = httpClient.PutAsJsonAsync($"api/shops/{id}", shopDetails);
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }

    public Task DeleteShopAsync(Guid id)
    {
        var response = httpClient.DeleteAsync($"api/shops/{id}");
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }

    public Task<List<ShopInventory>?> GetShopInventories(Guid shopId)
    {
        return httpClient.GetFromJsonAsync<List<ShopInventory>?>($"api/shops/{shopId}/inventories");
    }
}
