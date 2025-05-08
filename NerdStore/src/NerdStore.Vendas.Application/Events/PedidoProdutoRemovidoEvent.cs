using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoProdutoRemovidoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid PedidoId { get; private set; }


        public PedidoProdutoRemovidoEvent(Guid clienteId, Guid produtoId, Guid pedidoId)
        {
            AggregateId = pedidoId;
            ClienteId = clienteId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
        }
    }
}
