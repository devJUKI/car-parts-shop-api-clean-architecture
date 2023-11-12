using FluentValidation;

namespace Application.Features.Part.Commands.UpdatePart;

public class UpdateShopCommandValidator : AbstractValidator<UpdatePartCommand>
{
    public UpdateShopCommandValidator()
    {
        RuleFor(dto => dto.Id).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.Name).NotEmpty();
        RuleFor(dto => dto.Price).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.CarId).NotEmpty().GreaterThan(0);
        RuleFor(dto => dto.ShopId).NotEmpty().GreaterThan(0);
    }
}
