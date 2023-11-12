using Application.Features.Part.Common;
using MediatR;
using System.Security.Claims;

namespace Application.Features.Part.Commands.CreatePart;

public record CreatePartCommand(
    string Name,
    double Price,
    int CarId,
    int ShopId,
    ClaimsPrincipal User) : IRequest<PartResponse>;