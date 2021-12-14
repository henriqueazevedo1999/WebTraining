namespace BusinessLogicalLayer.Validators.Cliente;

internal class UpdateClienteValidator : ClienteValidator
{
    public UpdateClienteValidator()
    {
        base.ValidateId();
        base.ValidateNome();
        base.ValidateEmail();
        base.ValidateTelefone();
    }
}
