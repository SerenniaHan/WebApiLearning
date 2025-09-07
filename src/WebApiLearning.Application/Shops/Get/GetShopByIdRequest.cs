using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Shops.Get;

public record GetShopByIdRequest(Guid Id) : IRequest<Result<Option<Shop>>>;
