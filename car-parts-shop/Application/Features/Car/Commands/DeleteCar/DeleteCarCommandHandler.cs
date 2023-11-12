using Application.Authorization.Constants;
using Application.Exceptions;
using Application.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Application.Features.Car.Commands.DeleteCar;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
{
    private readonly ICarRepository _carRepository;
    private readonly IAuthorizationService _authorizationService;

    public DeleteCarCommandHandler(ICarRepository carRepository, IAuthorizationService authorizationService)
    {
        _carRepository = carRepository;
        _authorizationService = authorizationService;
    }

    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(request.ShopId, request.Id);

        if (car == null)
        {
            throw new EntityNotFoundException("Car with given id was not found");
        }

        var authorizationResult = await _authorizationService.AuthorizeAsync(request.User, car.Shop, Policies.ResourceOwner);

        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedException("Authorization failed");
        }

        await _carRepository.DeleteAsync(car);
    }
}
