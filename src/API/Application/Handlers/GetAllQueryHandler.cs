using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Notifications;
using ClienteAPI.Application.Queries;
using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, DataResponse<Cliente>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Cliente> _repository;

    public GetAllQueryHandler(IMediator mediator, IRepository<Cliente> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<DataResponse<Cliente>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.GetAll();
            if (!response.HasSuccess)
            {
                return await Task.FromResult(ResponseFactory.CreateDataResponseFailure<Cliente>(response.Message));
            }

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new ErrorNotification(ex));
            return await Task.FromResult(ResponseFactory.CreateDataResponseFailure<Cliente>(ex));
        }
    }
}
