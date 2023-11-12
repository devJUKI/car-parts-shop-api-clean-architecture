using Application.Features.Car.Common;
using MediatR;
using System.Security.Claims;

namespace Application.Features.Car.Commands.UpdateCar;

public record UpdateCarCommand(
    int Id,
    DateTime FirstRegistration,
    int Mileage,
    float Engine,
    int Power,
    int BodyTypeId,
    int FuelTypeId,
    int GearboxTypeId,
    int ModelId,
    int ShopId,
    ClaimsPrincipal User) : IRequest<UpdateCarResponse>;
