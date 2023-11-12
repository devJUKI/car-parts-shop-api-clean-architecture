using Application.Interfaces.Authentication;
using Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using Application.Behaviours;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.Authorization.Requirements;
using Application.Authorization.Policies.Handlers;
using Application.Authorization.Constants;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddSingleton<IAuthorizationHandler, ResourceOwnerRequirementHandler>();
        services.AddAuthorization(o => 
            o.AddPolicy(Policies.ResourceOwner, policy =>
                policy.Requirements.Add(new ResourceOwnerRequirement())));

        return services;
    }
}
