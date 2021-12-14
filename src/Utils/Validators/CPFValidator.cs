using Utils.Extensions;
using FluentValidation;

namespace Utils.Validators;

public class CPFValidator : AbstractValidator<string>
{
    public CPFValidator()
    {
        RuleFor(x => x).NotEmpty().WithMessage("CPF deve ser informado.")
            .Must(x => x.IsValidCPF()).WithMessage("CPF inválido.");
    }
}
