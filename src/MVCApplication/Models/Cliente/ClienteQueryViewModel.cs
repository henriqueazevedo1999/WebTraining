using System;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models.Cliente;

public class ClienteQueryViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }
    public bool Ativo { get; set; }
}
