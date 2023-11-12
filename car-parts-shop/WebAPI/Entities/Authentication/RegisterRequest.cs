namespace WebAPI.Entities.Authentication;

public record RegisterRequest(
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email,
    string Password);
