using Api.Models;
using FluentValidation;

namespace Api.Validators;

public class ItemModelValidator : AbstractValidator<ItemModel>
{
    public ItemModelValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.CategoryId)
            .NotEmpty();

        RuleFor(x => x.Image)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.Image))
            .WithMessage("{PropertyName}: {PropertyValue} is not a valid url");

        RuleFor(c => c.Amount)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);

        RuleFor(c => c.Name)
            .MaximumLength(50)
            .NotEmpty();
        
        RuleFor(c => c.Price)
            .GreaterThanOrEqualTo(0)
            .LessThan(100000000)
            .Must(p => p % 0.01m == 0)
            .WithMessage("{PropertyName}: only 2 digits after point are allowed but {PropertyValue} has more");
    }
}
