using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Shops.Get;

public record GetAllShopsRequest : IRequest<Result<IReadOnlyCollection<Shop>>>;
