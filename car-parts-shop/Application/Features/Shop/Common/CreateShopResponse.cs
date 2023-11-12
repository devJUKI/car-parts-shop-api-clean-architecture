namespace Application.Features.Shop.Common;

public record CreateShopResponse(
    int Id,
    string Name,
    string Location);