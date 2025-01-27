using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Business.Models
{
    public abstract class Transacao : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public Conta ContaOrigem { get; set; }
        // preciso ainda verificar se é cartão ou não...

        // EF Relations
        public Guid FaturaId { get; set; }
        public Fatura Fatura { get; set; }

        protected Transacao(string descricao, decimal valor, DateTime data, TipoTransacao tipo, Conta contaOrigem)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            TipoTransacao = tipo;
            ContaOrigem = contaOrigem;
        }
    }
}
