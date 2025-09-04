using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Put;

public record UpdateCommand(
    Guid Id,
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice,
    int Damage,
    float AttackSpeed
) : IRequest;

public record UpdateRequest(
    string Name,
    ERarity Rarity,
    int PurchasePrice,
    int SellPrice,
    int Damage,
    float AttackSpeed
);
