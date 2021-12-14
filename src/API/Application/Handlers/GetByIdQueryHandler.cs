using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Notifications;
using ClienteAPI.Application.Queries;
using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, SingleResponse<Cliente>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Cliente> _repository;

    public GetByIdQueryHandler(IMediator mediator, IRepository<Cliente> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<SingleResponse<Cliente>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.Get(request.Id);
            if (!response.HasSuccess)
            {
                return await Task.FromResult(ResponseFactory.CreateSingleResponseFailure<Cliente>(response.Message));
            }

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new ErrorNotification(ex));
            return await Task.FromResult(ResponseFactory.CreateSingleResponseFailure<Cliente>(ex));
        }
    }
}
