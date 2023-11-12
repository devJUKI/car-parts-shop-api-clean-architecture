using Application.Features.Shop.Common;

namespace Application.Features.Car.Common;

public record CarResponse(
    int Id,
    DateTime FirstRegistration,
    int Mileage,
    float Engine,
    int Power,
    string Body,
    string Fuel,
    string Gearbox,
    string Model,
    ShopResponse Shop);
