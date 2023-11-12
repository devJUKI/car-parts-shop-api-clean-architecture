using Application.Features.Shop.Common;
using MediatR;

namespace Application.Features.Shop.Commands.CreateShop;

public record CreateShopCommand(
    string Name,
    string Location,
    Guid UserId) : IRequest<ShopResponse>;