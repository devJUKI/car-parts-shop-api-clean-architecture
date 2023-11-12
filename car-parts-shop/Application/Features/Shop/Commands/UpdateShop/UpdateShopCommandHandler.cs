using Application.Exceptions;
using Application.Features.Shop.Common;
using Application.Interfaces.Persistence;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Application.Authorization.Constants;

namespace Application.Features.Shop.Commands.UpdateShop;

public class UpdateShopCommandHandler : IRequestHandler<UpdateShopCommand, ShopResponse>
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public UpdateShopCommandHandler(IShopRepository shopRepository, IMapper mapper, IAuthorizationService authorizationService)
    {
        _shopRepository = shopRepository;
        _mapper = mapper;
        _authorizationService = authorizationService;
    }

    public async Task<ShopResponse> Handle(UpdateShopCommand request, CancellationToken cancellationToken)
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

        var existingShop = await _shopRepository.GetAsync(request.Name);

        if (existingShop != null)
        {
            throw new ConflictException("Shop with this name already exists");
        }

        shop.Name = request.Name;
        shop.Location = request.Location;

        await _shopRepository.UpdateAsync(shop);

        return _mapper.Map<ShopResponse>(shop);
    }
}
