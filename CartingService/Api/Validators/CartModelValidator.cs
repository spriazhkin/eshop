using Api.Models;
using FluentValidation;

namespace Api.Validators;

public class CartModelValidator : AbstractValidator<CartModel>
{
    public CartModelValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.Items)
            .NotEmpty()
            .Must(i => i.Select(e => e.Id).Distinct().Count() == i.Count)
            .WithMessage("{PropertyName}: multiple items with same ids are not allowed in cart");

        RuleForEach(c => c.Items)
            .SetValidator(new CartItemModelValidator());
    }
}
