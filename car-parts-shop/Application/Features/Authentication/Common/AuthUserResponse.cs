namespace Application.Features.Authentication.Common;

public record AuthUserResponse(
    UserResponse User,
    string Token);
