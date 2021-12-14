using MediatR;

namespace ClienteAPI.Application.Notifications;

public class DeletedNotification : INotification
{
    public DeletedNotification(int id, bool ehEfetivado)
    {
        Id = id;    
        EhEfetivado = ehEfetivado;
    }

    public int Id { get; set; }
    public bool EhEfetivado { get; set; }
}
