using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class VoucherAplicadoPedidoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public string VoucherId { get; private set; }
        public VoucherAplicadoPedidoEvent(Guid clienteId, Guid pedidoId, string voucherCodigo)
        {
            AggregateId = pedidoId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
            VoucherId = voucherCodigo;
        }


    }
}
