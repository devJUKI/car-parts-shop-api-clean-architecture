using MediatR;
using AutoMapper;
using Application.Features.Shop.Common;
using Application.Interfaces.Persistence;

namespace Application.Features.Shop.Queries.GetAllShops;

public class GetAllShopsQueryHandler : IRequestHandler<GetAllShopsQuery, IEnumerable<ShopResponse>>
{
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public GetAllShopsQueryHandler(IShopRepository shopRepository, IMapper mapper)
    {
        _shopRepository = shopRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShopResponse>> Handle(GetAllShopsQuery request, CancellationToken cancellationToken)
    {
        var shops = await _shopRepository.GetAllAsync();
        return shops.Select(_mapper.Map<ShopResponse>);
    }
}
