using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Inventories.Dtos;

public static class Extensions
{
    public static InventoryDto ToDto(this Inventory inventory)
    {
        return new InventoryDto(inventory.Id);
    }
}
