using FluentValidation;

namespace Utils.Validators;

public class BirthdateValidator : AbstractValidator<DateTime>
{
    public BirthdateValidator()
    {
        RuleFor(x => x).GreaterThan(DateTime.Now.AddYears(-110)).WithMessage("Data inválida.");
    }
}
