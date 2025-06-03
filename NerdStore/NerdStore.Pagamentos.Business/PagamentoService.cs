using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.DomainObjects.DTO;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Pagamentos.Business
{
    public class PagamentoService : IPagamentoService
    {
        //Parei a aula aos 16:13. Estava implementando a camada Anti-Corruption.
        private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMediatrHandler _mediatrHandler;

        public PagamentoService(IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade, IPagamentoRepository pagamentoRepository, IMediatrHandler mediatrHandler)
        {
            _pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
            _pagamentoRepository = pagamentoRepository;
            _mediatrHandler = mediatrHandler;
        }

        public async Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido)
        {
            var pedido = new Pedido
            {
                Id = pagamentoPedido.PedidoId,
                Valor = pagamentoPedido.Total
            };

            var pagamento = new Pagamento
            {
                Valor = pagamentoPedido.Total,
                NomeCartao = pagamentoPedido.NomeCartao,
                NumeroCartao = pagamentoPedido.NumeroCartao,
                ExpiracaoCartao = pagamentoPedido.ExpiracaoCartao,
                CvvCartao = pagamentoPedido.CvvCartao,
                PedidoId = pedido.Id
            };

            var transacao = _pagamentoCartaoCreditoFacade.RealizarPagamento(pedido, pagamento);

            if (transacao.StatusTransacao == StatusTransacao.Pago)
            {
                pagamento.AdicionarEvento(new PagamentoRealizadoEvent(
                    pagamentoPedido.PedidoId,
                    pagamentoPedido.ClienteId,
                    pagamentoPedido.Total,
                    pagamentoPedido.NomeCartao,
                    pagamentoPedido.NumeroCartao,
                    pagamentoPedido.ExpiracaoCartao,
                    pagamentoPedido.CvvCartao));

                _pagamentoRepository.Adicionar(pagamento);
                _pagamentoRepository.AdicionarTransacao(transacao);

                await _pagamentoRepository.UnitOfWork.Commit();
                return transacao;

            }

            await _mediatrHandler.PublicarNotificacao(new DomainNotification("Pagamento", "A operadora recusou o pagamento."));
            await _mediatrHandler.PublicarEvento(new PagamentoRecusadoEvent(
                pagamentoPedido.PedidoId,
                pagamentoPedido.ClienteId,
                pagamentoPedido.Total,
                pagamentoPedido.NomeCartao,
                pagamentoPedido.NumeroCartao,
                pagamentoPedido.ExpiracaoCartao,
                pagamentoPedido.CvvCartao));

            return transacao;
        }
    }
}
