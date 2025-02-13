using NerdStore.Core.Data;
using NerdStore.Vendas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Data.Repository
{
    internal class PedidoRepository : IPedidoRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Adicionar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoItem> ObterItemPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> ObterPedidoRascunhoPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
