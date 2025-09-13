using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Application.Weapons.Commands.CreateWeapon;
using WebApiLearning.Application.Weapons.Commands.DeleteWeaponById;
using WebApiLearning.Application.Weapons.Commands.UpdateWeapon;
using WebApiLearning.Application.Weapons.Queries.GetAllWeapon;
using WebApiLearning.Application.Weapons.Queries.GetWeaponById;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Api.Endpoints;

public static class WeaponEndpoints
{
    public static RouteGroupBuilder MapWeaponEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/weapons");

        // create new weapon item endpoint - from json body
        group.MapPost(
            "/",
            async ([FromBody] CreateWeaponRequest request, ISender sender) =>
            {
                var response = await sender.Send(request);
                return response.Match(
                    Succ: weapon => Results.Created($"/api/weapons/{weapon.Id}", weapon),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // create new weapon item endpoint - from query parameters
        group.MapPost(
            "/create",
            async (
                [FromQuery] string name,
                [FromQuery] string rarity,
                [FromQuery] int purchasePrice,
                [FromQuery] int sellPrice,
                [FromQuery] int damage,
                [FromQuery] decimal attackSpeed,
                ISender sender
            ) =>
            {
                if (!Enum.TryParse<ERarity>(rarity, true, out var parsedRarity))
                {
                    return Results.BadRequest($"Invalid rarity value: {rarity}");
                }
                var request = new CreateWeaponRequest(
                    name,
                    parsedRarity,
                    purchasePrice,
                    sellPrice,
                    damage,
                    attackSpeed
                );
                var response = await sender.Send(request);
                return response.Match(
                    Succ: weapon => Results.Created($"/api/weapons/{weapon.Id}", weapon),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // get all weapon items endpoint
        group.MapGet(
            "/",
            async (ISender sender) =>
            {
                var result = await sender.Send(new GetAllWeaponRequest());
                return result.Match(
                    Some: weapons => Results.Ok(weapons),
                    None: () => Results.Problem("Could not retrieve weapons")
                );
            }
        );

        // get weapon item by id endpoint
        group.MapGet(
            "/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetWeaponByIdRequest(id));
                return result.Match(
                    Succ: option =>
                        option.Match(
                            Some: weapon => Results.Ok(weapon),
                            None: () => Results.NotFound()
                        ),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // delete weapon item by id endpoint
        group.MapDelete(
            "/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteByIdRequest(id));
                return result.Match(
                    Succ: _ => Results.NoContent(),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // update weapon item by id endpoint - from json body
        group.MapPut(
            "/{id:guid}",
            async (Guid id, [FromBody] UpdateRequest request, ISender sender) =>
            {
                var updateRequest = new UpdateCommand(
                    id,
                    request.Name,
                    request.Rarity,
                    request.PurchasePrice,
                    request.SellPrice,
                    request.Damage,
                    request.AttackSpeed
                );
                await sender.Send(updateRequest);
                return Results.NoContent();
            }
        );

        return group;
    }
}
