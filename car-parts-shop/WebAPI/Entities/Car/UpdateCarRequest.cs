namespace WebAPI.Entities.Car;

public record UpdateCarRequest(
    int Id,
    DateTime FirstRegistration,
    int Mileage,
    float Engine,
    int Power,
    int BodyTypeId,
    int FuelTypeId,
    int GearboxTypeId,
    int ModelId,
    int ShopId);
