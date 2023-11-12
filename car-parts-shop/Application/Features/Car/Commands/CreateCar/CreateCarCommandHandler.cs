using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Features.Car.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Car.Commands.CreateCar;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IShopRepository _shopRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    public CreateCarCommandHandler(
        ICarRepository carRepository,
        IShopRepository shopRepository,
        IAuthorizationService authorizationService,
        IMapper mapper)
    {
        _carRepository = carRepository;
        _shopRepository = shopRepository;
        _authorizationService = authorizationService;
        _mapper = mapper;
    }

    public async Task<CarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var bodyType = await _carRepository.GetBodyAsync(request.BodyTypeId);
        var fuelType = await _carRepository.GetFuelAsync(request.FuelTypeId);
        var gearboxType = await _carRepository.GetGearboxAsync(request.GearboxTypeId);
        var model = await _carRepository.GetModelAsync(request.ModelId);
        var shop = await _shopRepository.GetAsync(request.ShopId);

        if (bodyType == null || fuelType == null || gearboxType == null || model == null || shop == null)
        {
            throw new BadRequestException("Input details were incorrect");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(request.User, shop, Policies.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        var car = new Core.Entities.Car
        {
            FirstRegistration = request.FirstRegistration,
            Mileage = request.Mileage,
            Engine = request.Engine,
            Power = request.Power,
            Body = bodyType,
            Fuel = fuelType,
            Gearbox = gearboxType,
            Model = model,
            Shop = shop
        };

        await _carRepository.CreateAsync(car);

        return _mapper.Map<CarResponse>(car);
    }
}
