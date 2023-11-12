using FluentValidation;

namespace Application.Features.Part.Commands.CreatePart;

public class CreatePartCommandValidator : AbstractValidator<CreatePartCommand>
{
    public CreatePartCommandValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty();
        RuleFor(dto => dto.Price).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.CarId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.ShopId).NotEmpty().GreaterThan(0);
    }
}
