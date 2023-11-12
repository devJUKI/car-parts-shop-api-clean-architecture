using Application.Exceptions;
using Application.Features.Car.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Car.Queries.GetAllCars;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<CarResponse>>
{
    private readonly IShopRepository _shopRepository;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllCarsQueryHandler(IShopRepository shopRepository, ICarRepository carRepository, IMapper mapper)
    {
        _shopRepository = shopRepository;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var shop = await _shopRepository.GetAsync(request.ShopId);

        if (shop == null)
        {
            throw new EntityNotFoundException("Shop with given id was not found");
        }

        var cars = await _carRepository.GetAllAsync(request.ShopId);

        return cars.Select(_mapper.Map<CarResponse>);
    }
}
