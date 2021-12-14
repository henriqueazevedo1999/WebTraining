using BusinessLogicalLayer.Interfaces;
using ClienteAPI.Application.Commands;
using ClienteAPI.Application.Notifications;
using MediatR;
using MetaData.Entities;
using Utils.Response;

namespace ClienteAPI.Application.Handlers;

public class CadastraCommandHandler : IRequestHandler<CadastraCommand, SingleResponse<Cliente>>
{
    private readonly IMediator _mediator;
    private readonly IRepository<Cliente> _repository;

    public CadastraCommandHandler(IMediator mediator, IRepository<Cliente> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }

    public async Task<SingleResponse<Cliente>> Handle(CadastraCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            Nome = request.Nome,
            CPF = request.CPF,
            DataNascimento = request.DataNascimento,
            Email = request.Email,
            Telefone = request.Telefone,
        };

        try
        {
            var response = await _repository.Insert(cliente);
            if (!response.HasSuccess)
            {
                await _mediator.Publish(new CreatedNotification(cliente));
                //await _mediator.Publish(new ErrorNotification(response));
                return await Task.FromResult(response);
            }

            await _mediator.Publish(new CreatedNotification(response.Item));
            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new ErrorNotification(ex));
            return await Task.FromResult(ResponseFactory.CreateSingleResponseFailure<MetaData.Entities.Cliente>(ex));
        }
    }
}
