namespace Application.Entities;

public record UserResponse(
    Guid Id,
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email,
    string Token);
