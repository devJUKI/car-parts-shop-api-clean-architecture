using Application.Exceptions;
using Application.Features.Part.Common;
using Application.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Part.Queries.GetPart;

public class GetPartQueryHandler : IRequestHandler<GetPartQuery, PartResponse>
{
    private readonly IPartRepository _partRepository;
    private readonly IMapper _mapper;

    public GetPartQueryHandler(IPartRepository partRepository, IMapper mapper)
    {
        _partRepository = partRepository;
        _mapper = mapper;
    }

    public async Task<PartResponse> Handle(GetPartQuery request, CancellationToken cancellationToken)
    {
        var part = await _partRepository.GetAsync(request.ShopId, request.CarId, request.PartId);

        if (part == null)
        {
            throw new EntityNotFoundException("Part with given id was not found");
        }

        return _mapper.Map<PartResponse>(part);
    }
}
