using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiLearning.Application.Weapons.Commands.Create;
using WebApiLearning.Application.Weapons.Commands.Delete;
using WebApiLearning.Application.Weapons.Commands.Update;
using WebApiLearning.Application.Weapons.Queries.GetById;
using WebApiLearning.Application.Weapons.Queries.GetByName;
using WebApiLearning.Application.Weapons.Queries.List;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Api.Endpoints;

public static class WeaponEndpoints
{
    public static RouteGroupBuilder MapWeaponEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/weapons");

        // create new weapon item endpoint - from JSON body
        group.MapPost(
            "/",
            async ([FromBody] CreateWeaponCommand weaponCommand, ISender sender) =>
            {
                var response = await sender.Send(weaponCommand);
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
                var request = new CreateWeaponCommand(
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
                var result = await sender.Send(new ListWeaponsQuery());
                return result.Match(
                    Succ: Results.Ok,
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // get weapon item by id endpoint
        group.MapGet(
            "/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetWeaponByIdQuery(id));
                return result.Match(
                    Succ: option => option.Match(Some: Results.Ok, None: () => Results.NotFound()),
                    Fail: error => Results.Problem(error.Message)
                );
            }
        );

        // get weapon item by name endpoint
        group.MapGet(
            "/{name}",
            async (string name, ISender sender) =>
            {
                var result = await sender.Send(new GetWeaponByNameQuery(name));
                return result.Match(Some: Results.Ok, None: () => Results.NotFound());
            }
        );

        // delete weapon item by id endpoint
        group.MapDelete(
            "/{id:guid}",
            async (Guid id, ISender sender) =>
            {
                await sender.Send(new DeleteWeaponCommand(id));
                return Results.NoContent();
            }
        );

        // update weapon item by id endpoint - from JSON body
        group.MapPut(
            "/{id:guid}",
            async (Guid id, [FromBody] UpdateWeaponCommand command, ISender sender) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("ID in URL does not match ID in body");
                }
                await sender.Send(command);
                return Results.NoContent();
            }
        );

        return group;
    }
}
