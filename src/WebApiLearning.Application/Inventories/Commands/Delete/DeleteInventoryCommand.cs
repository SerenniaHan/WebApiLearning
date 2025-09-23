using LanguageExt.Common;
using MediatR;

namespace WebApiLearning.Application.Inventories.Commands.Delete;

public sealed record DeleteInventoryCommand(Guid Id) : IRequest<Result<bool>>;
