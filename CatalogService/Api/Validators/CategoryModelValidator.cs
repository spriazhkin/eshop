using Api.Models;
using FluentValidation;

namespace Api.Validators;

public class CategoryModelValidator : AbstractValidator<CategoryModel>
{
    public CategoryModelValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.Name)
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.ImageUrl)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.ImageUrl))
            .WithMessage("{PropertyName}: {PropertyValue} is not a valid url");
    }
}
