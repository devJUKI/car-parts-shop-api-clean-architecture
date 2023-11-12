using Application.Exceptions;
using Application.Features.Part.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Part.Queries.GetAllParts;

public class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQuery, IEnumerable<PartResponse>>
{
    private readonly ICarRepository _carRepository;
    private readonly IPartRepository _partRepository;
    private readonly IMapper _mapper;

    public GetAllPartsQueryHandler(ICarRepository carRepository, IPartRepository partRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _partRepository = partRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PartResponse>> Handle(GetAllPartsQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetAsync(request.ShopId, request.CarId);

        if (car == null)
        {
            throw new EntityNotFoundException("Car with given id was not found");
        }

        var parts = await _partRepository.GetAllAsync(request.ShopId, request.CarId);

        return parts.Select(_mapper.Map<PartResponse>);
    }
}
