using Application.Exceptions;
using Application.Features.Car.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Car.Queries.GetCar;

public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarResponse> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(request.ShopId, request.CarId);
        
        if (car == null)
        {
            throw new EntityNotFoundException("Car with given id was not found");
        }

        return _mapper.Map<CarResponse>(car);
    }
}
