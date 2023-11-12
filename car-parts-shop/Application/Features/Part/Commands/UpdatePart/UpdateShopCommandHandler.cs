using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Features.Part.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Part.Commands.UpdatePart;

public class UpdateShopCommandHandler : IRequestHandler<UpdatePartCommand, PartResponse>
{
    private readonly IPartRepository _partRepository;
    private readonly ICarRepository _carRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    public UpdateShopCommandHandler(
        IPartRepository partRepository,
        ICarRepository carRepository,
        IAuthorizationService authorizationService,
        IMapper mapper)
    {
        _partRepository = partRepository;
        _carRepository = carRepository;
        _authorizationService = authorizationService;
        _mapper = mapper;
    }

    public async Task<PartResponse> Handle(UpdatePartCommand request, CancellationToken cancellationToken)
    {
        var part = await _partRepository.GetAsync(request.ShopId, request.CarId, request.Id);

        if (part == null)
        {
            throw new EntityNotFoundException("Part with given id was not found");
        }

        var car = await _carRepository.GetAsync(request.ShopId, request.CarId);

        var authorizationResult = await _authorizationService.AuthorizeAsync(request.User, car!.Shop, Policies.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        part.Name = request.Name;
        part.Price = request.Price;

        await _partRepository.UpdateAsync(part);

        return _mapper.Map<PartResponse>(part);
    }
}
