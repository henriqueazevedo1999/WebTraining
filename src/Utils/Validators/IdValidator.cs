using FluentValidation;

namespace Utils.Validators;

public class IdValidator : AbstractValidator<int>
{
    public IdValidator()
    {
        RuleFor(x => x).GreaterThan(0).WithMessage("ID deve ser maior que zero.");
    }
}