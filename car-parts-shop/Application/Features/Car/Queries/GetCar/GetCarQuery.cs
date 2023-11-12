using Application.Features.Car.Common;
using MediatR;

namespace Application.Features.Car.Queries.GetCar;

public record GetCarQuery(int ShopId, int CarId) : IRequest<CarResponse>;
