using Application.Features.Part.Common;
using MediatR;

namespace Application.Features.Part.Queries.GetAllParts;

public record GetAllPartsQuery(int ShopId, int CarId) : IRequest<IEnumerable<PartResponse>>;
