﻿using NerdStore.Core.DomainObjects;

namespace NerdStore.Pagamentos.Business
{
    public class Transacao : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
