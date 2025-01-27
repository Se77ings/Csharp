

using Financas.Business.Models;

namespace Financas.Business.Interfaces
{
    public interface IFaturaService : IDisposable
    {
        Task Adicionar(Fatura fatura);
        Task Atualizar(Fatura fatura);
    }
}
