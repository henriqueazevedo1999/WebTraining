using MediatR;
using MetaData.Entities;

namespace ClienteAPI.Application.Notifications;

public class DeactivatedNotification : BaseClienteNotification, INotification
{
    public DeactivatedNotification(Cliente cliente, bool ehEfetivado) : base(cliente, ehEfetivado)
    {
    }
}
