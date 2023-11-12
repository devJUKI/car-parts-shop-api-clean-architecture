namespace WebAPI.Entities.Part;

public record UpdatePartRequest(
    int Id,
    string Name,
    double Price,
    int CarId,
    int ShopId);