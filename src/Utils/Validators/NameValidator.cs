using FluentValidation;

namespace Utils.Validators;

public class NameValidator : AbstractValidator<string>
{
    public NameValidator()
    {
        RuleFor(x => x).NotEmpty().WithMessage("Nome deve ser informado.")
                .Length(3, 70).WithMessage("Nome deve conter entre 3 e 70 caracteres");
    }
}
