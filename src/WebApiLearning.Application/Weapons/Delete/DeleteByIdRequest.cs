using LanguageExt.Common;
using MediatR;

namespace WebApiLearning.Application.Weapons.Delete;

public record DeleteByIdRequest(Guid Id) : IRequest<Result<Guid>>;
