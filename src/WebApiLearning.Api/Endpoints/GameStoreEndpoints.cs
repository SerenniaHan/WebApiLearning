using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Contracts;
using WebApiLearning.Core.Entities;
using WebApiLearning.Core.Repository;

namespace WebApiLearning.Api.Endpoints;

public static class GameStoreEndpoints
{
    public static RouteGroupBuilder MapGameStoreEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/gamestore");

        // get all game items
        group.MapGet("/", async (IGameStoreRepository repo) =>
        {
            var items = await repo.GetItemsAsync();
            return Results.Ok(items.Select(i => i.ToGameItemResponse()));
        });

        // get game item by id
        group.MapGet("/{id:guid}", async (Guid id, IGameStoreRepository repo) =>
        {
            var item = await repo.GetItemAsync(id);
            if (item is null) return Results.NotFound();
            return Results.Ok(item.ToGameItemResponse());
        });

        // create new game item
        group.MapPost("/", async ([FromBody] CreateGameItemRequest request, IGameStoreRepository repo) =>
        {
            var item = new GameItem(Guid.NewGuid(), request.Name, request.Price);
            await repo.CreateItemAsync(item);
            return Results.Created($"/api/gamestore/{item.Id}", item.ToGameItemResponse());
        });

        // update game item
        group.MapPut("/{id:guid}", async (Guid id, [FromBody] UpdateGameItemRequest? request, IGameStoreRepository repo) =>
        {
            if (request is null) return Results.BadRequest();

            var existingItem = await repo.GetItemAsync(id);
            if (existingItem is null) return Results.NotFound();

            var updatedItem = existingItem with
            {
                Name = request.Name,
                Price = request.Price
            };
            await repo.UpdateItemAsync(updatedItem);
            return Results.NoContent();
        });

        // patch update game item
        /* group.MapPatch("/{id}", async (string? id, [FromBody] JsonPatchDocument<UpdateGameItemRequest>? patchDoc, IGameStoreRepository repo) =>
        {
            if (id is null) return Results.BadRequest();
            if (patchDoc is null) return Results.BadRequest();

            var existingItem = await repo.GetItemAsync(id);
            if (existingItem is null) return Results.NotFound();

            var patchRequest = new UpdateGameItemRequest(existingItem.Name, existingItem.Price);
            patchDoc.ApplyTo(patchRequest);

            // manually validate the patched DTO
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(patchRequest, null, null);
            if (!Validator.TryValidateObject(patchRequest, validationContext, validationResults, true))
            {
                var errors = validationResults
                    .GroupBy(vr => vr.MemberNames.FirstOrDefault() ?? string.Empty)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(vr => vr.ErrorMessage ?? string.Empty).ToArray()
                    );
                return Results.ValidationProblem(errors);
            }

            // apply changes and save
            var updatedItem = existingItem with
            {
                Name = patchRequest.Name,
                Price = patchRequest.Price
            };
            await repo.UpdateItemAsync(updatedItem);

            return Results.NoContent();
        }); */

        // delete game item
        group.MapDelete("/{id:guid}", async (Guid? id, IGameStoreRepository repo) =>
        {
            if (id is null) return Results.BadRequest();

            var existingItem = await repo.GetItemAsync(id.Value);
            if (existingItem is null) return Results.NotFound();

            await repo.DeleteItemAsync(id.Value);
            return Results.NoContent();
        });

        return group;
    }
}
