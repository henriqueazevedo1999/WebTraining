using MediatR;
using Utils.Response;

namespace ClienteAPI.Application.Commands;

public class ExcluiCommand : IRequest<Response>
{
    public int Id { get; set; }
}
