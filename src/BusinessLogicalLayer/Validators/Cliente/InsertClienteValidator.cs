namespace BusinessLogicalLayer.Validators.Cliente;

public class InsertClienteValidator : ClienteValidator
{
    public InsertClienteValidator()
    {
        base.ValidateNome();
        base.ValidateCPF();
        base.ValidateDataNascimento();  
        base.ValidateEmail();   
        base.ValidateTelefone();    
    }
}
