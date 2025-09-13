using LanguageExt.Common;
using MediatR;

namespace WebApiLearning.Application.Weapons.Commands.DeleteWeaponById;

public record DeleteByIdRequest(Guid Id) : IRequest<Result<Guid>>;
