using Application.Interfaces.Persistence;
using Application.Features.Shop.Common;
using AutoMapper;
using MediatR;
using Application.Exceptions;

namespace Application.Features.Shop.Commands.CreateShop;

public class CreateShopCommandHandler : IRequestHandler<CreateShopCommand, CreateShopResponse>
{
    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public CreateShopCommandHandler(IShopRepository shopRepository, IMapper mapper)
    {
        _shopRepository = shopRepository;
        _mapper = mapper;
    }

    public async Task<CreateShopResponse> Handle(CreateShopCommand request, CancellationToken cancellationToken)
    {
        var existingShop = await _shopRepository.GetAsync(request.Name);

        if (existingShop != null)
        {
            throw new ConflictException("Shop with this name already exists");
        }

        var shop = new Core.Entities.Shop
        {
            Name = request.Name,
            Location = request.Location,
            UserId = request.UserId
        };

        await _shopRepository.CreateAsync(shop);

        return _mapper.Map<CreateShopResponse>(shop);
    }
}
