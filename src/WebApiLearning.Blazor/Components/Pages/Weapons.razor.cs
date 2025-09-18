using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Components.Pages;

public partial class Weapons
{
    private List<Weapon>? weapons;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        weapons = await WeaponService.AllWeapons();
    }

    private static string EditWeaponUrl(Guid id) => $"/editweapon/{id}";
}
