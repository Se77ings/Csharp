using Financas.Business.Interfaces;
using Financas.Business.Models;

namespace Financas.Business.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public async Task Adicionar(Transacao transacao)
        {
            await _transacaoRepository.Adicionar(transacao);
        }

        public async Task Atualizar(Transacao transacao)
        {
            await Atualizar(transacao);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
