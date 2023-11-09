using Application.Entities;
using Application.Interfaces.Authentication;
using Application.Interfaces.Persistence;
using Core.Entities;

namespace Application.Services.Authentication;

internal class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserResponse> Login(LoginRequest request)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception("User with this email was not found");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Firstname, user.Lastname);

        bool isPasswordCorrect = _passwordHasher.Verify(request.Password, user.HashedPassword);
        if (isPasswordCorrect == false)
        {
            throw new Exception("Credentials are wrong");
        }

        return new UserResponse(
            user,
            token);
    }

    public async Task<UserResponse> Register(RegisterRequest request)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new Exception("User with that email already exists");
        }

        var userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, request.Firstname, request.Lastname);

        string hashedPassword = _passwordHasher.Hash(request.Password);

        var user = new User
        {
            Id = userId,
            Email = request.Email,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            PhoneNumber = request.PhoneNumber,
            HashedPassword = hashedPassword
        };

        await _userRepository.CreateUserAsync(user);

        return new UserResponse(
            user,
            token);
    }
}
