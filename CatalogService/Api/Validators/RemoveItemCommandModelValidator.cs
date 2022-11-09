using Api.Models.Commands;
using FluentValidation;

namespace Api.Validators;

public class RemoveItemCommandModelValidator : AbstractValidator<RemoveItemCommandModel>
{
    public RemoveItemCommandModelValidator()
    {
        RuleFor(c => c.ItemId)
            .NotEmpty();
        RuleFor(c => c.CartId)
            .NotEmpty();
    }
}
