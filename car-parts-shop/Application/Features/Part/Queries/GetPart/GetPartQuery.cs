using Application.Features.Part.Common;
using MediatR;

namespace Application.Features.Part.Queries.GetPart;

public record GetPartQuery(
    int ShopId,
    int CarId,
    int PartId) : IRequest<PartResponse>;
