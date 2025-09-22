using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Services;

public class WeaponService
{
    private readonly HttpClient _httpClient;

    public WeaponService(IConfiguration configuration)
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

    public Task<List<WeaponDetails>?> AllWeapons()
    {
        return _httpClient.GetFromJsonAsync<List<WeaponDetails>>("api/weapons");
    }

    public Task<bool> AddNewWeapon(WeaponDetails weapon)
    {
        var response = _httpClient.PostAsJsonAsync("api/weapons", weapon);
        return response.ContinueWith(t => t.Result.IsSuccessStatusCode);
    }

    public Task<WeaponDetails?> GetWeaponById(Guid id)
    {
        return _httpClient.GetFromJsonAsync<WeaponDetails?>($"api/weapons/{id}");
    }

    public Task UpdateWeapon(Guid id, WeaponDetails weaponDetails)
    {
        var response = _httpClient.PutAsJsonAsync($"api/weapons/{id}", weaponDetails);
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }

    public Task DeleteWeaponAsync(Guid id)
    {
        var response = _httpClient.DeleteAsync($"api/weapons/{id}");
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }
}
