using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>, INotificationHandler<PedidoIniciadoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMediatrHandler _mediator;
        public ProdutoEventHandler(IProdutoRepository produtoRep, IEstoqueService estoqueService, IMediatrHandler mediator)
        {
            _produtoRepository = produtoRep;
            _estoqueService = estoqueService;
            _mediator = mediator;
        }
        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            //aqui lida com a lógica de negócio.
            //pode ser enviado um email para a equipe de vendas, por exemplo.           
        }

        public async Task Handle(PedidoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(notification.ProdutosPedido);

            if (result)
            {

                await _mediator.PublicarEvento(new PedidoEstoqueConfirmadoEvent(notification.PedidoId, notification.ClienteId, notification.Total, notification.ProdutosPedido, notification.NomeCartao, notification.NumeroCartao, notification.ExpiracaoCartao, notification.CvvCartao);
            }
            else
            {

                await _mediator.PublicarEvento(new PedidoEstoqueRejeitadoEvent(notification.PedidoId, notification.ClienteId));

            }
        }
    }
}
