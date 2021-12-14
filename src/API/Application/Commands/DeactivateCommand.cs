using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Commands;

public class DeactivateCommand : IRequest<SingleResponse<Cliente>>
{
    public int Id { get; set; }
}
