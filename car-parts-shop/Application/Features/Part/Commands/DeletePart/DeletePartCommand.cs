using MediatR;
using System.Security.Claims;

namespace Application.Features.Part.Commands.DeletePart;

public record DeletePartCommand(
    int ShopId,
    int CarId,
    int PartId,
    ClaimsPrincipal User) : IRequest;
