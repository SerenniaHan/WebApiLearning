using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Weapons.Queries.GetWeaponById;

public record GetWeaponByIdRequest(Guid Id) : IRequest<Result<Option<Weapon>>>;
