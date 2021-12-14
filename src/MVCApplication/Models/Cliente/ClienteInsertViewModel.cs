using System;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models.Cliente;

//model: classe usada para desenhar a tela
//contém o que se "vê na interface"
public class ClienteInsertViewModel
{
    [Required(ErrorMessage = "Nome deve ser informado")]
    [StringLength(70, MinimumLength = 4, ErrorMessage = "Nome deve conter entre 4 e 70 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "CPF deve ser informado")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "Telefone deve ser informado")]
    public string Telefone { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Data de nascimento deve ser informada")]
    public DateTime DataNascimento { get; set; }
}
