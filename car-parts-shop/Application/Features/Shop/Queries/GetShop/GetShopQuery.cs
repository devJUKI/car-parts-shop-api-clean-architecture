using Application.Features.Shop.Common;
using MediatR;

namespace Application.Features.Shop.Queries.GetShop;

public record GetShopQuery(int Id) : IRequest<ShopResponse?>;