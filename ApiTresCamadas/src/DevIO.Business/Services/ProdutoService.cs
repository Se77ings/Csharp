using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System.Linq.Expressions;

namespace DevIO.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService 
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador) 
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produto entity)
        {

            if (!ExecutarValidacao(new ProdutoValidation(), entity)) return;

            await _produtoRepository.Adicionar(entity);
        }

        public async Task Atualizar(Produto entity)
        {
            if(!ExecutarValidacao(new ProdutoValidation(), entity)) return;
            await _produtoRepository.Atualizar(entity);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }

        public Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> ObterTodos()
        {
            throw new NotImplementedException();
        }



        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
