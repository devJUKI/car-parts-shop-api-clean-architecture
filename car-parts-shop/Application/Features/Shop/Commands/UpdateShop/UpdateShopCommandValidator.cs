using FluentValidation;

namespace Application.Features.Shop.Commands.UpdateShop;

public class UpdateShopCommandValidator : AbstractValidator<UpdateShopCommand>
{
    public UpdateShopCommandValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty();
        RuleFor(dto => dto.Location).NotEmpty();
    }
}