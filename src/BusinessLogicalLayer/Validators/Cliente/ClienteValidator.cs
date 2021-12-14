using Utils.Validators;

namespace BusinessLogicalLayer.Validators.Cliente;

public class ClienteValidator : EntityValidator<MetaData.Entities.Cliente>
{
    public void ValidateNome()
    {
        RuleFor(x => x.Nome).SetValidator(new NameValidator());
    }

    public void ValidateCPF()
    {
        RuleFor(x => x.CPF).SetValidator(new CPFValidator());
    }

    public void ValidateTelefone()
    {
        RuleFor(x => x.Telefone).SetValidator(new PhoneValidator());
    }

    public void ValidateEmail()
    {
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
    }

    public void ValidateDataNascimento()
    { 
        RuleFor(x => x.DataNascimento).SetValidator(new BirthdateValidator());
    }
}
