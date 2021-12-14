using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Queries;

public class GetByIdQuery : IRequest<SingleResponse<Cliente>>
{
    public int Id { get; set; }
}
