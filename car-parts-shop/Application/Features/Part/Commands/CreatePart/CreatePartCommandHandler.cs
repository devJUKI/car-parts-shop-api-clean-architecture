using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Features.Part.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Part.Commands.CreatePart;

public class CreatePartCommandHandler : IRequestHandler<CreatePartCommand, PartResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IPartRepository _partRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    public CreatePartCommandHandler(
        ICarRepository carRepository,
        IPartRepository partRepository,
        IAuthorizationService authorizationService,
        IMapper mapper)
    {
        _carRepository = carRepository;
        _partRepository = partRepository;
        _authorizationService = authorizationService;
        _mapper = mapper;
    }

    public async Task<PartResponse> Handle(CreatePartCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(request.ShopId, request.CarId);
        
        if (car == null)
        {
            throw new EntityNotFoundException("Car with given id was not found");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(request.User, car.Shop, Policies.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        var part = new Core.Entities.Part
        {
            Name = request.Name,
            Price = request.Price,
            Car = car
        };

        await _partRepository.CreateAsync(part);

        return _mapper.Map<PartResponse>(part);
    }
}
