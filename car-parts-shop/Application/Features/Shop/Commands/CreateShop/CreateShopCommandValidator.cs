using FluentValidation;

namespace Application.Features.Shop.Commands.CreateShop;

public class CreateShopCommandValidator : AbstractValidator<CreateShopCommand>
{
    public CreateShopCommandValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty();
        RuleFor(dto => dto.Location).NotEmpty();
    }
}
