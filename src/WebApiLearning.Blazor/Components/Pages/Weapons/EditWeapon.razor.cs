using Microsoft.AspNetCore.Components;
using WebApiLearning.Blazor.Models;

namespace WebApiLearning.Blazor.Components.Pages.Weapons;

public partial class EditWeapon
{
    [Parameter]
    public Guid? Id { get; set; }

    [SupplyParameterFromForm]
    private WeaponDetails? WeaponDetails { get; set; }

    private string _title = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        if (WeaponDetails is not null)
        {
            return;
        }

        if (Id is not null)
        {
            WeaponDetails = await WeaponService.GetWeaponById(Id.Value);
        }
        else
        {
            WeaponDetails = WeaponDetails.Empty;
        }

        _title = WeaponDetails is null ? "New Weapon" : $"Edit {WeaponDetails.Name}";
    }

    private async Task HandleSubmitAsync()
    {
        ArgumentNullException.ThrowIfNull(WeaponDetails);
        if (Id is not null)
        {
            await WeaponService.UpdateWeapon(Id.Value, WeaponDetails);
        }
        else
        {
            await WeaponService.AddNewWeapon(
                new WeaponDetails
                {
                    Name = WeaponDetails.Name,
                    Rarity = WeaponDetails.Rarity,
                    Damage = WeaponDetails.Damage,
                    AttackSpeed = WeaponDetails.AttackSpeed,
                    PurchasePrice = WeaponDetails.PurchasePrice,
                    SellPrice = WeaponDetails.SellPrice,
                }
            );
        }
        NavigationManager.NavigateTo("/weapons");
    }
}
