using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financas.Business.Models.Tipos;

namespace Financas.Business.Models
{
    public class TransacaoCartao : Transacao

    {
        public TransacaoCartao(string descricao, DateTime data, TipoTransacao tipo, Conta contaOrigem) : base(descricao, 0, data, tipo, contaOrigem)
        {
            CartaoItens = new List<CartaoItem>();
        }
        public string NomeCartao { get; set; }
        public List<CartaoItem> CartaoItens { get; set; }
        
        public void AtualizarValor()
        {
            Valor = CartaoItens.Sum(c => c.Valor);
        }

    }
}
