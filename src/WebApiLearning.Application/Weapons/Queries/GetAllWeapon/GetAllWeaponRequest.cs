using LanguageExt;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Queries.GetAllWeapon;

public record GetAllWeaponRequest : IRequest<Option<IReadOnlyCollection<Weapon>>>;
