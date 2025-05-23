﻿using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        // EF Rel.
        public Pedido Pedido { get; set; }  // 1 : 1
        protected PedidoItem()
        {

        }


        public PedidoItem(Guid produtoId, string produtoNome, int qtd, decimal vlUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = qtd;
            ValorUnitario = vlUnitario;

        }
        //

        internal void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }
        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }
        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }

    }
}
