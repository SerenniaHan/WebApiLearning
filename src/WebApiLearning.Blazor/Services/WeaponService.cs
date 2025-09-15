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
}
