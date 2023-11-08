namespace Application.Entities;

public record RegisterRequest(
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email,
    string Password);
