using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Application.Inventories.Commands.Create;
using WebApiLearning.Application.Inventories.Commands.Delete;
using WebApiLearning.Application.Inventories.Queries.List;

namespace WebApiLearning.Api.Endpoints;

public static class InventoryEndpoints
{
    public static RouteGroupBuilder MapInventoryEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/inventories");

        // get all inventories summary endpoint
        group.MapGet(
            "/",
            async (ISender sender) =>
            {
                var query = new ListInventoriesQuery();
                var result = await sender.Send(query);
                return result.Match(
                    Succ: options => options.Match(Some: Results.Ok, None: Results.NoContent),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // create new inventory endpoint
        group.MapPost(
            "/",
            async ([FromBody] CreateInventoryCommand command, ISender sender) =>
            {
                var result = await sender.Send(command);
                return result.Match(
                    inventory => Results.Created($"/api/inventories/{inventory.Id}", inventory),
                    error => Results.Problem(error.Message)
                );
            }
        );

        // delete inventory endpoint
        group.MapDelete(
            "/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                var command = new DeleteInventoryCommand(id);
                var result = await sender.Send(command);
                return result.Match(
                    success => success ? Results.NoContent() : Results.NotFound(),
                    error => Results.Problem(error.Message)
                );
            }
        );

        return group;
    }
}
