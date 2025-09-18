using Microsoft.AspNetCore.Components;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Components.Pages.Weapons;

public partial class DeleteWeapon
{
    [Parameter]
    public Weapon? Weapon { get; set; }

    private string _title = string.Empty;

    protected override Task OnParametersSetAsync()
    {
        _title = $"Delete {Weapon?.Name} ?";
        return base.OnParametersSetAsync();
    }

    public static string GetModalId(Weapon? weapon)
    {
        ArgumentNullException.ThrowIfNull(weapon);
        return $"deleteWeaponModal{weapon.Id.ToString().Replace("-", string.Empty)}";
    }

    private async Task DeleteWeaponAsync()
    {
        if (Weapon == null)
        {
            return;
        }

        await WeaponService.DeleteWeaponAsync(Weapon.Id);
        NavigationManager.Refresh();
        //NavigationManager.NavigateTo("/weapons", forceLoad: true);
    }
}
