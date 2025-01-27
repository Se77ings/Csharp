using Financas.Business.Interfaces;
using Financas.Business.Models;


namespace Financas.Business.Services
{
    public class FaturaService : IFaturaService
    {
        private readonly IFaturaRepository _faturaRepository;

        public FaturaService(IFaturaRepository faturaRepository)
        {
            _faturaRepository = faturaRepository;
        }
        public async Task Adicionar(Fatura fatura)
        {
            //validações e os krl
            await _faturaRepository.Adicionar(fatura);
        }

        public async Task Atualizar(Fatura fatura)
        {
            await _faturaRepository.Atualizar(fatura);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
