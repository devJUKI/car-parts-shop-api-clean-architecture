using Application.Entities;

namespace Application.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<UserResponse> Login(LoginRequest request);
    Task<UserResponse> Register(RegisterRequest request);
}
