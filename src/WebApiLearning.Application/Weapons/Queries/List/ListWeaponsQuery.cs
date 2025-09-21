using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;

namespace WebApiLearning.Application.Weapons.Queries.List;

public record ListWeaponsQuery : IRequest<Result<IReadOnlyCollection<WeaponDto>>>;
