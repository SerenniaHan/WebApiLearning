using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Post;

public record CreateWeaponRequest(
    [Required] string Name,
    [Required] ERarity Rarity,
    [Required] int PurchasePrice,
    [Required] int SellPrice,
    [Required] int Damage,
    [Required] float AttackSpeed
) : IRequest<Result<Weapon>>;
