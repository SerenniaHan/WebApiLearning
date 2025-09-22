using LanguageExt;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Inventories.Dtos;

namespace WebApiLearning.Application.Inventories.Queries.List;

public sealed record ListInventoriesQuery
    : IRequest<Result<Option<IReadOnlyCollection<InventorySummaryDto>>>>;
