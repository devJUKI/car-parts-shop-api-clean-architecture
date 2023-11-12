using MediatR;
using AutoMapper;
using Application.Features.Shop.Common;
using Application.Interfaces.Persistence;
using Application.Exceptions;

namespace Application.Features.Shop.Queries.GetShop;

public class GetShopQueryHandler : IRequestHandler<GetShopQuery, ShopResponse?>
{
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public GetShopQueryHandler(IShopRepository shopRepository, IMapper mapper)
    {
        _shopRepository = shopRepository;
        _mapper = mapper;
    }

    public async Task<ShopResponse?> Handle(GetShopQuery request, CancellationToken cancellationToken)
    {
        var shop = await _shopRepository.GetAsync(request.Id);

        if (shop == null)
        {
            throw new EntityNotFoundException("Shop with given id was not found");
        }

        return _mapper.Map<ShopResponse>(shop);
    }
}
