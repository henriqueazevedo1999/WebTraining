using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Commands;
using ClienteAPI.Application.Notifications;
using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class DeactivateCommandHandler : IRequestHandler<DeactivateCommand, SingleResponse<Cliente>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Cliente> _repository;

    public DeactivateCommandHandler(IMediator mediator, IRepository<Cliente> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<SingleResponse<Cliente>> Handle(DeactivateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.Deactivate(request.Id);
            if (!response.HasSuccess)
            {
                await _mediator.Publish(new DeactivatedNotification(response.Item, false));
                return await Task.FromResult(response);
            }

            await _mediator.Publish(new DeactivatedNotification(response.Item, true));
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new ErrorNotification(ex));
            return await Task.FromResult(ResponseFactory.CreateSingleResponseFailure<Cliente>(ex));
        }

    }
}
