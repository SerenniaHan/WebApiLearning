using WebApiLearning.Contracts;

namespace WebApiLearning.Core.Entities;

public static class EntityExtension
{
    public static GameItemResponse ToGameItemResponse(this GameItem item)
    {
        return new GameItemResponse(item.Id.ToString(), item.Name, item.Price);
    }
}
