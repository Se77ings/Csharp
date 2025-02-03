using FinancasKiss.Business.Models;

namespace FinancasKiss.Business.Services.Interfaces
{
    public interface ITransacaoService
    {
        void AdicionarTransacao(Transacao transacao, int mes);
        void RemoverTransacao(Transacao transacao, int mes);
    }
}
