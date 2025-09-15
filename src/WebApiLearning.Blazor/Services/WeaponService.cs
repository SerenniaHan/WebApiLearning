using WebApiLearning.Blazor.Models;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Services;

public class WeaponService
{
    private HttpClient _httpClient;

    public WeaponService()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7031/") };
    }

    public Task<List<Weapon>?> AllWeapons() =>
        _httpClient.GetFromJsonAsync<List<Weapon>>("api/weapons");

    public Task<bool> AddNewWeapon(Weapon weapon)
    {
        var response = _httpClient.PostAsJsonAsync("api/weapons", weapon);
        return response.ContinueWith(t => t.Result.IsSuccessStatusCode);
    }

    public Task<Weapon?> GetWeaponById(Guid id) =>
        _httpClient.GetFromJsonAsync<Weapon?>($"api/weapons/{id}");

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
