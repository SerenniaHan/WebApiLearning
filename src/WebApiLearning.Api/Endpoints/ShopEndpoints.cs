using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Application.Shops.Commands.CreateShop;
using WebApiLearning.Application.Shops.Queries.GetAllShops;
using WebApiLearning.Application.Shops.Queries.GetShopById;
using WebApiLearning.Application.Shops.Queries.GetShopInventories;

namespace WebApiLearning.Api.Endpoints;

public static class ShopEndpoints
{
    public static RouteGroupBuilder MapShopEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/shops");

        // create new shop item endpoint - from json body
        group.MapPost(
            "/",
            async ([FromBody] CreateShopRequest request, ISender sender) =>
            {
                var response = await sender.Send(request);
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
                var response = await sender.Send(new GetAllShopsRequest());
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
                var response = await sender.Send(new GetShopByIdRequest(id));
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

        return group;
    }
}
