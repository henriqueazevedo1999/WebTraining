using FluentValidation;

namespace Utils.Validators;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator()
    {
        RuleFor(x => x).NotEmpty().WithMessage("Email deve ser informado.")
            .Length(10, 100).WithMessage("Email deve conter entre 10 e 100 caracteres.")
            .EmailAddress().WithMessage("Email inválido.");
    }
}
