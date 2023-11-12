using Application.Features.Car.Commands.UpdateCar;
using FluentValidation;

namespace Application.Features.Car.Commands.DeleteCar;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(dto => dto.Id).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.FirstRegistration).NotEmpty().GreaterThan(new DateTime(1700, 1, 1));
        RuleFor(dto => dto.Mileage).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.Engine).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.Power).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.BodyTypeId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.FuelTypeId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.GearboxTypeId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.ModelId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.ShopId).NotEmpty().GreaterThan(0);
    }
}
