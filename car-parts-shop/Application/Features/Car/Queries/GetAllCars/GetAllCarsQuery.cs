using Application.Features.Car.Common;
using MediatR;

namespace Application.Features.Car.Queries.GetAllCars;

public record GetAllCarsQuery(int ShopId) : IRequest<IEnumerable<CarResponse>>;
