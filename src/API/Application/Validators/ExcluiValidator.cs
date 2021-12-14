using ClienteAPI.Application.Commands;
using FluentValidation;

namespace ClienteAPI.Application.Validators;

public class ExcluiValidator : AbstractValidator<ExcluiCommand>
{
    public ExcluiValidator()
    {
        this.ValidateId();
    }

    public void ValidateId()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("ID informado inválido")
            .GreaterThan(0).WithMessage("ID deve ser maior que zero.");
    }
}
