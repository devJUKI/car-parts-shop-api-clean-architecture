using Application.Features.Shop.Common;
using MediatR;

namespace Application.Features.Shop.Queries.GetAllShops;

public record GetAllShopsQuery() : IRequest<IEnumerable<ShopResponse>>;