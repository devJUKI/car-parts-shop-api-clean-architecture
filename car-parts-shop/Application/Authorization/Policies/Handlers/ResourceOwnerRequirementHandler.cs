using Application.Authorization.Constants;
using Application.Authorization.Policies.Requirements;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Authorization.Policies.Handlers;

public class ResourceOwnerRequirementHandler : AuthorizationHandler<ResourceOwnerRequirement, IUserOwnedResource>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        ResourceOwnerRequirement requirement,
        IUserOwnedResource resource)
    {
        bool isUserAdmin = context.User.IsInRole(Roles.Administrator);
        Guid userId = new(context.User.FindFirstValue(JwtRegisteredClaimNames.Sub)!);
        bool isUserResourceOwner = userId == resource.UserId;

        if (isUserAdmin || isUserResourceOwner)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}