using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Shops.Queries.GetAllShops;

public record GetAllShopsRequest : IRequest<Result<IReadOnlyCollection<Shop>>>;
