using FluentValidation;
using ClienteAPI.Application.Commands;
using Utils.Extensions;

namespace ClienteAPI.Application.Validators;

public class AlteraValidator : AbstractValidator<AlteraCommand>
{
    public AlteraValidator()
    {
        ValidateNome();
        ValidateCPF();
        ValidateTelefone();
        ValidateEmail();
        ValidateDataNascimento();
    }

    public void ValidateNome()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome deve ser informado.")
            .Length(3, 70).WithMessage("Nome deve conter entre 3 e 70 caracteres");
    }

    public void ValidateCPF()
    {
        RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF deve ser informado.")
            .Must(x => x.IsValidCPF()).WithMessage("CPF inválido.");
    }

    public void ValidateTelefone()
    {
        RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone deve ser informado.")
            .Length(9, 15).WithMessage("Telefone deve conter entre 9 e 15 caracteres.");
    }

    public void ValidateEmail()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email deve ser informado.")
            .Length(10, 100).WithMessage("Email deve conter entre 10 e 100 caracteres.")
            .EmailAddress().WithMessage("Email inválido.");
    }

    public void ValidateDataNascimento()
    {
        RuleFor(x => x.DataNascimento).GreaterThan(DateTime.Now.AddYears(-110)).WithMessage("Data inválida.");
    }
}
