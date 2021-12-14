using MediatR;
using MetaData.Entities;

namespace ClienteAPI.Application.Notifications;

public class ChangedNotification : BaseClienteNotification, INotification
{
    public ChangedNotification(Cliente cliente, bool ehEfetivado) : base(cliente, ehEfetivado)
    {
    }
}
