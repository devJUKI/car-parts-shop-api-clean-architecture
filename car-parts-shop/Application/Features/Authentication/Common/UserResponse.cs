namespace Application.Features.Authentication.Common;

public record UserResponse(
    Guid Id,
    string Email,
    string Firstname,
    string Lastname,
    string PhoneNumber);
