using LanguageExt;
using LanguageExt.Common;
using Microsoft.Extensions.DependencyInjection;
using WebApiLearning.Contracts;
using WebApiLearning.Core.UseCases;

namespace WebApiLearning.Core;

public static class Extensions
{
    public static IServiceCollection AddWebApiLearningCore(this IServiceCollection services)
    {
        services.AddTransient<ICommandAsync<Result<AllGameItemsResponse>>, GetAllGameItemsCommandAsync>();
        services.AddTransient<ICommandAsync<GetItemRequest, Result<Option<GameItemResponse>>>, GetGameItemCommandAsync>();
        return services;
    }
}
