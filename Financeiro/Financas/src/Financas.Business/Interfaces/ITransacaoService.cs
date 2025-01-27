using Financas.Business.Models;


namespace Financas.Business.Interfaces
{
    public interface ITransacaoService : IDisposable
    {
        Task Adicionar(Transacao transacao);
        Task Atualizar(Transacao transacao);
    }
}
