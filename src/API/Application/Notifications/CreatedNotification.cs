using MediatR;
using MetaData.Entities;

namespace ClienteAPI.Application.Notifications;

public class CreatedNotification : INotification
{
    public CreatedNotification(Cliente cliente)
    {
        Id = cliente.ID;
        Nome = cliente.Nome;
        CPF = cliente.CPF;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
}

