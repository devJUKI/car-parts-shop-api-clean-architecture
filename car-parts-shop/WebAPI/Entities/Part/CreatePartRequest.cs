namespace WebAPI.Entities.Part;

public record CreatePartRequest(
    string Name,
    double Price,
    int CarId,
    int ShopId);
