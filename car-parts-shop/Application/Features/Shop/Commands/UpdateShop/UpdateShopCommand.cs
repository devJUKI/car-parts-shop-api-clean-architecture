using Application.Features.Shop.Common;
using MediatR;
using System.Security.Claims;

namespace Application.Features.Shop.Commands.UpdateShop;

public record UpdateShopCommand(
    int Id,
    string Name,
    string Location,
    ClaimsPrincipal User) : IRequest<UpdateShopResponse>;
