using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Commands.Create;

public record CreateWeaponCommand(
    [Required] string Name,
    [Required] ERarity Rarity,
    [Required] int PurchasePrice,
    [Required] int SellPrice,
    [Required] int Damage,
    [Required] decimal AttackSpeed
) : IRequest<Result<WeaponDto>>;
