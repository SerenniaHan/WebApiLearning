using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;
using MediatR;
using WebApiLearning.Domain.Entities;

namespace WebApiLearning.Application.Shops.Post;

public record CreateShopRequest([Required] string Name, [Required] string Location)
    : IRequest<Result<Shop>>;
