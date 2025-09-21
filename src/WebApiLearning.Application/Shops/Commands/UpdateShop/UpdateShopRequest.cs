using System.ComponentModel.DataAnnotations;
using MediatR;

namespace WebApiLearning.Application.Shops.Commands.UpdateShop;

public record UpdateShopRequest(
    [Required] Guid Id,
    [Required] string Name,
    [Required] string Location
) : IRequest;
