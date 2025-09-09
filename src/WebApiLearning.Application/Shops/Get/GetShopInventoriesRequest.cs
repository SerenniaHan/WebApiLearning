using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace WebApiLearning.Application.Shops.Get;

public record GetShopInventoriesRequest(Guid Id)
    : IRequest<Result<Option<IReadOnlyCollection<GetShopInventoriesResponse>>>>;
