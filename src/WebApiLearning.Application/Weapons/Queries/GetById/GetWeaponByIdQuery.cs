using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;

namespace WebApiLearning.Application.Weapons.Queries.GetById;

public record GetWeaponByIdQuery(Guid Id) : IRequest<Result<Option<WeaponDto>>>;
