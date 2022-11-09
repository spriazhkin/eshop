using Api.Models.Commands;
using FluentValidation;

namespace Api.Validators;

public class AddItemCommandModelValidator : AbstractValidator<AddItemCommandModel>
{
    public AddItemCommandModelValidator()
    {
        RuleFor(c => c.CartId)
            .NotEmpty();
        
        RuleFor(c => c.Item)
            .SetValidator(new CartItemModelValidator());
    }
}
