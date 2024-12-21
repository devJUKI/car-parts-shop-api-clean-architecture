using Application.Exceptions;
using Application.Features.Authentication.Common;
using Application.Interfaces.Authentication;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher passwordHasher,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<AuthUserResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);

        if (user == null)
        {
            throw new EntityNotFoundException("User with this email was not found");
        }

        var roles = await _userRepository.GetUserRolesAsync(user.Id);
        var rolesNames = roles.Select(r => r.Name).ToList();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Firstname, user.Lastname, rolesNames);

        bool isPasswordCorrect = _passwordHasher.Verify(request.Password, user.HashedPassword);

        if (isPasswordCorrect == false)
        {
            throw new UnauthorizedException("Wrong credentials");
        }

        return new AuthUserResponse(
            _mapper.Map<UserResponse>(user),
            token);
    }
}
