using LanguageExt.Common;
using MediatR;

namespace WebApiLearning.Application.Weapons.Commands.Delete;

public record DeleteWeaponCommand(Guid Id) : IRequest<Result<bool>>;
