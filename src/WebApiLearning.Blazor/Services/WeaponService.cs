using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Services;

public class WeaponService(HttpClient httpClient)
{
    public Task<List<WeaponDetails>?> AllWeapons()
    {
        return httpClient.GetFromJsonAsync<List<WeaponDetails>>("api/weapons");
    }

    public Task<bool> AddNewWeapon(WeaponDetails weapon)
    {
        var response = httpClient.PostAsJsonAsync("api/weapons", weapon);
        return response.ContinueWith(t => t.Result.IsSuccessStatusCode);
    }

    public Task<WeaponDetails?> GetWeaponById(Guid id)
    {
        return httpClient.GetFromJsonAsync<WeaponDetails?>($"api/weapons/{id}");
    }

    public Task UpdateWeapon(Guid id, WeaponDetails weaponDetails)
    {
        var response = httpClient.PutAsJsonAsync($"api/weapons/{id}", weaponDetails);
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }

    public Task DeleteWeaponAsync(Guid id)
    {
        var response = httpClient.DeleteAsync($"api/weapons/{id}");
        return response.ContinueWith(t => t.Result.EnsureSuccessStatusCode());
    }
}
