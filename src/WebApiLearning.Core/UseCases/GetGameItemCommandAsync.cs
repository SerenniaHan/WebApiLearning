using LanguageExt;
using LanguageExt.Common;
using WebApiLearning.Contracts;
using WebApiLearning.Core.Entities;
using WebApiLearning.Core.Repository;

namespace WebApiLearning.Core.UseCases;

public class GetGameItemCommandAsync(IGameStoreRepository repository) : ICommandAsync<GetItemRequest, Result<Option<GameItemResponse>>>
{
    public async Task<Result<Option<GameItemResponse>>> HandleAsync(GetItemRequest request)
    {
        try
        {
            var item = await repository.GetItemAsync(request.Id);
            if (item is null)
            {
                return new Result<Option<GameItemResponse>>(Option<GameItemResponse>.None);
            }

            return new Result<Option<GameItemResponse>>(item.ToGameItemResponse());
        }
        catch (Exception e)
        {
            return new Result<Option<GameItemResponse>>(e);
        }
    }
}