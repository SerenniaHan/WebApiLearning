using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Commands.Update;

public record UpdateWeaponCommand(
    Guid Id,
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice,
    int Damage,
    decimal AttackSpeed
) : IRequest<Result<WeaponDto>>;
