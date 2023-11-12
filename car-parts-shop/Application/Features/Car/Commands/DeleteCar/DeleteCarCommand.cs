using MediatR;
using System.Security.Claims;

namespace Application.Features.Car.Commands.DeleteCar;

public record DeleteCarCommand(
    int ShopId,
    int Id,
    ClaimsPrincipal User) : IRequest;
