using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Queries;

public class GetAllQuery : IRequest<DataResponse<Cliente>>
{
}
