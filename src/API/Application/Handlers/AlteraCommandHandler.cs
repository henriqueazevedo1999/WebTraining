using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Commands;
using ClienteAPI.Application.Notifications;
using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class AlteraCommandHandler : IRequestHandler<AlteraCommand, SingleResponse<Cliente>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Cliente> _repository;

    public AlteraCommandHandler(IMediator mediator, IRepository<MetaData.Entities.Cliente> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<SingleResponse<Cliente>> Handle(AlteraCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            ID = request.Id,
            Nome = request.Nome,
            DataNascimento = request.DataNascimento,
            Telefone = request.Telefone,
            Email = request.Email,
            CPF = request.CPF,
            Ativo = request.Ativo
        };

        try
        {
            var response = await _repository.Update(cliente);
            if (!response.HasSuccess)
            {
                await _mediator.Publish(new ChangedNotification(cliente, false));
                return await Task.FromResult(ResponseFactory.CreateSingleResponseFailure<Cliente>(response.Message));
            }

            await _mediator.Publish(new ChangedNotification(cliente, true));
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            //TODO: Precisa desses 2?
            await _mediator.Publish(new ChangedNotification(cliente, false));
            await _mediator.Publish(new ErrorNotification(ex));
            return await Task.FromResult(ResponseFactory.CreateSingleResponseFailure<Cliente>(ex));
        }
    }
}
