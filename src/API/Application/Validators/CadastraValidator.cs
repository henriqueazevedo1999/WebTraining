using ClienteAPI.Application.Commands;
using FluentValidation;
using Utils.Validators;

namespace ClienteAPI.Application.Validators;

public class CadastraValidator : AbstractValidator<CadastraCommand>
{
    public CadastraValidator()
    {
        RuleFor(x => x.Nome).SetValidator(new NameValidator());
        RuleFor(x => x.CPF).SetValidator(new CPFValidator());
        RuleFor(x => x.Telefone).SetValidator(new PhoneValidator());
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.DataNascimento).SetValidator(new BirthdateValidator());
    }
}
