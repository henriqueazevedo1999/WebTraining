using FluentValidation;

namespace Utils.Validators;

public class PhoneValidator : AbstractValidator<string>
{
    public PhoneValidator()
    {
        RuleFor(x => x).NotEmpty().WithMessage("Telefone deve ser informado.")
            .Length(9, 15).WithMessage("Telefone deve conter entre 9 e 15 caracteres.");
    }
}
