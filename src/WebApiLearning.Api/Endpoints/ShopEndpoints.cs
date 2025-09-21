using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Application.Shops.Commands.Create;
using WebApiLearning.Application.Shops.Commands.Delete;
using WebApiLearning.Application.Shops.Commands.Update;
using WebApiLearning.Application.Shops.Queries.GetById;
using WebApiLearning.Application.Shops.Queries.GetShopInventories;
using WebApiLearning.Application.Shops.Queries.List;

namespace WebApiLearning.Api.Endpoints;

public static class ShopEndpoints
{
    public static RouteGroupBuilder MapShopEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/shops");

        // create new shop item endpoint - from json body
        group.MapPost(
            "/",
            async ([FromBody] CreateShopCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);
                return response.Match(
                    Succ: shop => Results.Created($"/api/shops/{shop.Id}", shop),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // get all shops endpoint
        group.MapGet(
            "/",
            async (ISender sender) =>
            {
                var response = await sender.Send(new ListShopsQuery());
                return response.Match(
                    Succ: shops => Results.Ok(shops),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // get shop by id endpoint
        group.MapGet(
            "/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                var response = await sender.Send(new GetShopByIdQuery(id));
                return response.Match(
                    Succ: option =>
                        option.Match(
                            Some: shop => Results.Ok(shop),
                            None: () => Results.NotFound()
                        ),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // get shop's inventory endpoint - from json body
        group.MapGet(
            "/{shopId:guid}/inventory",
            async (Guid shopId, ISender sender) =>
            {
                var response = await sender.Send(new GetShopInventoriesRequest(shopId));
                return response.Match(
                    Succ: option =>
                        option.Match(
                            Some: inventories => Results.Ok(inventories),
                            None: () => Results.NotFound()
                        ),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // update shop endpoint - from json body
        group.MapPut(
            "/{shopId:guid}",
            async (Guid shopId, [FromBody] UpdateShopCommand command, ISender sender) =>
            {
                await sender.Send(command with { Id = shopId });
                return Results.NoContent();
            }
        );

        // delete shop endpoint
        group.MapDelete(
            "/{shopId:guid}",
            async (Guid shopId, ISender sender) =>
            {
                await sender.Send(new DeleteShopCommand(shopId));
                return Results.NoContent();
            }
        );

        return group;
    }
}
