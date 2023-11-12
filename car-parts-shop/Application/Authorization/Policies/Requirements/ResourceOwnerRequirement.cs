using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization.Policies.Requirements;

public record ResourceOwnerRequirement : IAuthorizationRequirement;
