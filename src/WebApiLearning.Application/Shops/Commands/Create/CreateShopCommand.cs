using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Application.Shops.Dto;

namespace WebApiLearning.Application.Shops.Commands.Create;

public record CreateShopCommand([Required] string Name, [Required] string Location)
    : IRequest<Result<ShopDto>>;
