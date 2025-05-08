using NerdStore.Core.DomainObjects.DTO;

namespace NerdStore.Catalogo.Domain
{
    public interface IEstoqueService : IDisposable
    {
        public Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        public Task<bool> DebitarListaProdutosPedido(ListaProdutoPedido lista);
        public Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade);
        public Task<bool> ReporEstoque(Guid produtoId, int quantidade);
        public Task<bool> ReporListaProdutosPedido(ListaProdutoPedido lista);
        public Task<bool> ReporItemEstoque(Guid produtoId, int quantidade);
    }
}
