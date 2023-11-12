namespace WebAPI.Entities.Shop;

public record UpdateShopRequest(
    int Id,
    string Name,
    string Location);
