using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Part.Commands.DeletePart;

public class DeletePartCommandHandler : IRequestHandler<DeletePartCommand>
{
    private readonly IPartRepository _partRepository;
    private readonly IAuthorizationService _authorizationService;

    public DeletePartCommandHandler(IPartRepository partRepository, IAuthorizationService authorizationService)
    {
        _partRepository = partRepository;
        _authorizationService = authorizationService;
    }

    public async Task Handle(DeletePartCommand request, CancellationToken cancellationToken)
    {
        var part = await _partRepository.GetAsync(request.ShopId, request.CarId, request.PartId);

        if (part == null)
        {
            throw new EntityNotFoundException("Part with given id was not found");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(request.User, part.Car!.Shop, Policies.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        await _partRepository.DeleteAsync(part);
    }
}
