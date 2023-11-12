using Core.Entities;

namespace Application.Features.Authentication.Common;

public record AuthUserResponse(
    User User,
    string Token);
