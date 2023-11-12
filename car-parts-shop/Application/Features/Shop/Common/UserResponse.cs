namespace Application.Features.Shop.Common;

public record UserResponse(
    string Id,
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email);

