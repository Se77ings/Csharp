
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using static NerdStore.Core.Messages.CommonMessages.Notifications.DomainNotification;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public readonly DomainNotificationHandler _notifications;

        private readonly IMediatrHandler _mediatorHandler;
        // simulando cliente logado
        protected Guid ClienteId = Guid.Parse("d65af519-fafe-4fc8-8557-af2c828a8bb9");
        public ControllerBase(MediatR.INotificationHandler<DomainNotification> notifications, IMediatrHandler mediatr)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatr;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }
    }
}