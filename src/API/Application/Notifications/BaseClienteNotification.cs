using MediatR;
using MetaData.Entities;

namespace ClienteAPI.Application.Notifications;

public abstract class BaseClienteNotification : INotification
{
    public BaseClienteNotification(Cliente cliente, bool ehEfetivado)
    {
        Id = cliente?.ID ?? 0;
        Nome = cliente?.Nome ?? string.Empty;
        CPF = cliente?.CPF ?? string.Empty;
        EhEfetivado = ehEfetivado;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public bool EhEfetivado { get; set; }
}
