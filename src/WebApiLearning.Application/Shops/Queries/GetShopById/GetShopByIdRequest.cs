using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Shops.Queries.GetShopById;

public record GetShopByIdRequest(Guid Id) : IRequest<Result<Option<Shop>>>;
