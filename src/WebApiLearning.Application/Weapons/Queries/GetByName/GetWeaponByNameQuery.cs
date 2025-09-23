using System.ComponentModel.DataAnnotations;
using LanguageExt;
using MediatR;
using WebApiLearning.Application.Weapons.Dtos;

namespace WebApiLearning.Application.Weapons.Queries.GetByName;

public record GetWeaponByNameQuery([Required] string Name) : IRequest<Option<WeaponDto>>;
