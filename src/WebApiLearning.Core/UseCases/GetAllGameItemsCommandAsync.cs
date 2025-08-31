using LanguageExt.Common;
using WebApiLearning.Contracts;
using WebApiLearning.Core.Entities;
using WebApiLearning.Core.Repository;

namespace WebApiLearning.Core.UseCases;

public class GetAllGameItemsCommandAsync(IGameStoreRepository repository) : ICommandAsync<Result<AllGameItemsResponse>>
{
    public async Task<Result<AllGameItemsResponse>> HandleAsync()
    {
        try
        {
            var items = await repository.GetItemsAsync();
            return new Result<AllGameItemsResponse>(new AllGameItemsResponse(items.Select(i => i.ToGameItemResponse())));
        }
        catch (Exception e)
        {
            return new Result<AllGameItemsResponse>(e);
        }
    }
}