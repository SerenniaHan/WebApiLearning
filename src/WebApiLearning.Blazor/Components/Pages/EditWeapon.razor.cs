using Microsoft.AspNetCore.Components;
using WebApiLearning.Blazor.Models;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Blazor.Components.Pages;

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
            var weapon = await WeaponService.GetWeaponById(Id.Value);
            if (weapon is not null)
            {
                WeaponDetails = new WeaponDetails
                {
                    Name = weapon.Name,
                    Rarity = weapon.Rarity,
                    Damage = weapon.Damage,
                    AttackSpeed = weapon.AttackSpeed,
                    PurchasePrice = weapon.PurchasePrice,
                    SellPrice = weapon.SellPrice,
                };
                _title = $"Edit {WeaponDetails.Name}";
            }
        }
        else
        {
            WeaponDetails = WeaponDetails.Empty;
            _title = "New Weapon";
        }
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
                new Weapon(
                    Name: WeaponDetails.Name,
                    Rarity: WeaponDetails.Rarity,
                    Damage: WeaponDetails.Damage,
                    AttackSpeed: WeaponDetails.AttackSpeed,
                    PurchasePrice: WeaponDetails.PurchasePrice,
                    SellPrice: WeaponDetails.SellPrice
                )
            );
        }
        NavigationManager.NavigateTo("/weapons");
    }
}
