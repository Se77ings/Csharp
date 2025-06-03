using MediatR;

namespace NerdStore.Core.Messages.CommonMessages.Notifications
{
    public partial class DomainNotification
    {
        public class DomainNotificationHandler : INotificationHandler<DomainNotification>
        {
            public List<DomainNotification> _notifications;

            public Task Handle(DomainNotification message, CancellationToken cancellationToken)
            {
                _notifications.Add(message);
                return Task.CompletedTask;
            }

            public virtual List<DomainNotification> ObterNotificacoes()
            {
                return _notifications;
            }

            public virtual bool TemNotificacao()
            {
                return ObterNotificacoes().Any();
            }
            public DomainNotificationHandler()
            {
                _notifications = new List<DomainNotification>();
            }
        }
    }
}
