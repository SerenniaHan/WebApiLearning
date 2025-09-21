using MediatR;

namespace WebApiLearning.Application.Shops.Commands.DeleteShop;

public record DeleteShopRequest(Guid ShopId) : IRequest;
