using Application.Features.Part.Common;
using MediatR;
using System.Security.Claims;

namespace Application.Features.Part.Commands.UpdatePart;

public record UpdatePartCommand(
    int Id,
    string Name,
    double Price,
    int CarId,
    int ShopId,
    ClaimsPrincipal User) : IRequest<PartResponse>;
