namespace Application.Features.Car.Common;

public record CreateCarResponse(
    int Id,
    DateTime FirstRegistration,
    int Mileage,
    float Engine,
    int Power,
    string Body,
    string Fuel,
    string Gearbox,
    string Model);
