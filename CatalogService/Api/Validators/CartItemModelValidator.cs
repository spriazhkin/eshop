using Api.Models;
using FluentValidation;

namespace Api.Validators;

public class CartItemModelValidator : AbstractValidator<ItemModel>
{
    public CartItemModelValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
        
        RuleFor(c => c.Name)
            .NotEmpty();
        
        RuleFor(c => c.Price)
            .GreaterThanOrEqualTo(0)
            .Must(p => p % 0.01m == 0)
            .WithMessage("{PropertyName}: only 2 digits after point are allowed but {PropertyValue} has more");
        
        RuleFor(c => c.Quantity)
            .GreaterThan(0);
    }
}
