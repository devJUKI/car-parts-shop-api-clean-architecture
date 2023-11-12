using MediatR;
using System.Security.Claims;

namespace Application.Features.Shop.Commands.DeleteShop;

public record DeleteShopCommand(
    int Id,
    ClaimsPrincipal User) : IRequest;
