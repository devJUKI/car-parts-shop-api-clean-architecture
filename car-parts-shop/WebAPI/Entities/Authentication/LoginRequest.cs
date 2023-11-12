namespace WebAPI.Entities.Authentication;

public record LoginRequest(
    string Email,
    string Password);
