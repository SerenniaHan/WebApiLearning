using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Application.Inventories.Commands.CreateInventory;

namespace WebApiLearning.Api.Endpoints;

public static class InventoryEndpoints
{
    public static RouteGroupBuilder MapInventoryEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/inventories");

        // create new inventory endpoint
        group.MapPost(
            "/",
            async ([FromBody] CreateInventoryRequest request, ISender sender) =>
            {
                var result = await sender.Send(request);
                return result.Match(
                    inventory => Results.Created($"/api/inventories/{inventory.Id}", inventory),
                    error => Results.Problem(error.Message)
                );
            }
        );

        return group;
    }
}
