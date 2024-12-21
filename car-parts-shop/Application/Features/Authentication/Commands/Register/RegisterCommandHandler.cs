using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Features.Authentication.Common;
using Application.Interfaces.Authentication;
using Application.Interfaces.Persistence;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(
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

    public async Task<AuthUserResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);

        if (existingUser != null)
        {
            throw new ConflictException("User with that email already exists");
        }

        var userId = Guid.NewGuid();
        List<string> roleNames = [Roles.User];

        var token = _jwtTokenGenerator.GenerateToken(userId, request.Firstname, request.Lastname, roleNames);

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
        await _userRepository.AddRoleToUserAsync(user, Roles.User);

        return new AuthUserResponse(
            _mapper.Map<UserResponse>(user),
            token);
    }
}
