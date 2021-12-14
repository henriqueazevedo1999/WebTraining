using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Commands;

public class CadastraCommand : IRequest<SingleResponse<Cliente>>
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}
