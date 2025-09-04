using LanguageExt;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Get;

public record GetAllWeaponRequest : IRequest<Option<IReadOnlyCollection<Weapon>>>;
