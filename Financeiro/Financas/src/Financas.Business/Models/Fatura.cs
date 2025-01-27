using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Business.Models
{
    public class Fatura : Entity
    {

        public DateOnly DateOnly { get; set; }
        public string Mes { get; set; }
        public List<Transacao> Transacoes { get; set; }

        public Fatura()
        {
            Mes = DateOnly.ToString("MM");
            Transacoes = new List<Transacao>();
        }

        public decimal ExibirFatura()
        {
            decimal valor = 0;

            foreach(var transacao in Transacoes)
            {
                if(transacao.TipoTransacao == TipoTransacao.Despesa)
                {
                    valor -= transacao.Valor;
                }
                else
                {
                    valor += transacao.Valor;
                }
            }
            return valor;
        }
    }
}
