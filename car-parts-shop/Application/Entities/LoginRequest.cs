namespace Application.Entities;

public record LoginRequest(
    string Email,
    string Password);
