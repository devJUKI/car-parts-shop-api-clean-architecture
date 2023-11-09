using Core.Entities;

namespace Application.Entities;

public record UserResponse(
    User User,
    string Token);
