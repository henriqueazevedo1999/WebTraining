using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Commands;
using ClienteAPI.Application.Notifications;
using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class DeletaCommandHandler : IRequestHandler<ExcluiCommand, Response>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Cliente> _repository;

    public DeletaCommandHandler(IMediator mediator, IRepository<Cliente> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<Response> Handle(ExcluiCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _repository.Delete(request.Id);

            //O que dá para aproveitar do baseReponse? Talvez passar como parâmetro no notification?
            if (!response.HasSuccess)
            {
                await _mediator.Publish(new DeletedNotification(request.Id, false));
                return await Task.FromResult(response);
            }

            await _mediator.Publish(new DeletedNotification(request.Id, true));
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new DeletedNotification(request.Id, false));
            await _mediator.Publish(new ErrorNotification(ex));
            return await Task.FromResult(ResponseFactory.CreateFailureResponse(ex));
        }
    }
}
