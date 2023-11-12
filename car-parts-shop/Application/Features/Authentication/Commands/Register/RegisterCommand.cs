using Application.Features.Authentication.Common;
using MediatR;

namespace Application.Features.Authentication.Commands.Register;

public record RegisterCommand(
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string Email,
    string Password) : IRequest<AuthUserResponse>;
