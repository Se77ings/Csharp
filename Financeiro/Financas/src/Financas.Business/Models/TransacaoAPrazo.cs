using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Business.Models
{
    public class TransacaoAPrazo : Transacao
    {
        public TransacaoAPrazo(string descricao, decimal valor, DateTime data, TipoTransacao tipo, Conta contaOrigem) : base(descricao, valor, data, tipo, contaOrigem)
        {
            
        }
        public int NumeroParcelas { get; set; }
        public List<DateOnly> Vencimentos { get; set; }
    }
}
