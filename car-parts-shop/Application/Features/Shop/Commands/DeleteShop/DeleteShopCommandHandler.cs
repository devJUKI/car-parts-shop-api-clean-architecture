using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Shop.Commands.DeleteShop;

public class DeleteShopCommandHandler : IRequestHandler<DeleteShopCommand>
{
    private readonly IShopRepository _shopRepository;
    private readonly IAuthorizationService _authorizationService;

    public DeleteShopCommandHandler(IShopRepository shopRepository, IAuthorizationService authorizationService)
    {
        _shopRepository = shopRepository;
        _authorizationService = authorizationService;
    }

    public async Task Handle(DeleteShopCommand request, CancellationToken cancellationToken)
    {
        var shop = await _shopRepository.GetAsync(request.Id);

        if (shop == null)
        {
            throw new EntityNotFoundException("Shop with given id was not found");
        }

        var result = await _authorizationService.AuthorizeAsync(request.User, shop, Policies.ResourceOwner);

        if (result.Succeeded == false)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        await _shopRepository.DeleteAsync(shop);
    }
}
