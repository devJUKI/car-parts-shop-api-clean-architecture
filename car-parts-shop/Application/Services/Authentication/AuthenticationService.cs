using Application.Entities;
using Application.Interfaces.Authentication;
using Application.Interfaces.Persistence;
using Core.Entities;
using System.Xml;

namespace Application.Services.Authentication;

internal class AuthenticationService : IAuthenticationService
{
    public Task<UserResponse> Login(LoginRequest request)
    {
        var user = new User
        {
            Email = request.Email,
            Firstname = "firstname",
            Lastname = "lastname",
            HashedPassword = "hash",
            PhoneNumber = "+37016565894"
        };

        return Task.FromResult(new UserResponse(
            user.Id,
            user.Firstname,
            user.Lastname,
            user.PhoneNumber,
            user.Email,
            "Token"));
    }

    public Task<UserResponse> Register(RegisterRequest request)
    {
        var user = new User
        {
            Email = request.Email,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            HashedPassword = request.Password,
            PhoneNumber = request.PhoneNumber
        };

        return Task.FromResult(new UserResponse(
            user.Id,
            user.Firstname,
            user.Lastname,
            user.PhoneNumber,
            user.Email,
            "Token"));
    }
}
