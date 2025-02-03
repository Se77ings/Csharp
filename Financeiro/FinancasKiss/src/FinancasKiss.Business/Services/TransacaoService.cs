using FinancasKiss.Business.Models;
using FinancasKiss.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasKiss.Business.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly DemonstrativoService _demonstrativoService;

        public TransacaoService(DemonstrativoService demonstrativoService)
        {
            _demonstrativoService = demonstrativoService;
        }

        public void AdicionarTransacao(Transacao transacao, int mes)
        {
            var demonstrativo = _demonstrativoService.ObterDemonstrativos().FirstOrDefault(d => d.Mes == mes);
            if (demonstrativo != null)
            {
                demonstrativo.AdicionarTransacao(transacao);
            }
        }

        public void RemoverTransacao(Transacao transacao, int mes)
        {
            var demonstrativo = _demonstrativoService.ObterDemonstrativos().FirstOrDefault(d => d.Mes == mes);
            if (demonstrativo != null)
            {
                demonstrativo.RemoverTransacao(transacao);
            }
        }
    }
}
