using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Features.Car.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Car.Commands.UpdateCar;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IShopRepository _shopRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;

    public UpdateCarCommandHandler(
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

    public async Task<CarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(request.ShopId, request.Id);

        if (car == null)
        {
            throw new EntityNotFoundException("Car with given id was not found");
        }

        var bodyType = await _carRepository.GetBodyAsync(request.BodyTypeId);
        var fuelType = await _carRepository.GetFuelAsync(request.FuelTypeId);
        var gearboxType = await _carRepository.GetGearboxAsync(request.GearboxTypeId);
        var model = await _carRepository.GetModelAsync(request.ModelId);
        var shop = await _shopRepository.GetAsync(request.ShopId);

        if (bodyType == null || fuelType == null || gearboxType == null || model == null || shop == null)
        {
            throw new BadRequestException("Input details were incorrect");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(request.User, car.Shop, Policies.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        car.FirstRegistration = request.FirstRegistration;
        car.Mileage = request.Mileage;
        car.Engine = request.Engine;
        car.Power = request.Power;
        car.Body = bodyType;
        car.Fuel = fuelType;
        car.Gearbox = gearboxType;
        car.Model = model;
        car.Shop = shop;

        await _carRepository.UpdateAsync(car);

        return _mapper.Map<CarResponse>(car);
    }
}
