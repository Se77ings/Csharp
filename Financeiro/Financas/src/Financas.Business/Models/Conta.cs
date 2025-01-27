using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Business.Models
{
    public class Conta : Entity
    {
        public string Nome { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public string Agencia { get; set; }
        public decimal Saldo { get; set; }
        public TipoConta TipoConta { get; set; }

        public Conta(string nome, string banco, string numero, string agencia, decimal saldo, TipoConta tipoConta)
        {
            Nome = nome;
            Banco = banco;
            Numero = numero;
            Agencia = agencia;
            Saldo = saldo;
            TipoConta = tipoConta;

        }

        ///* EF Relations */
        //public Banco Banco { get; set; }
        //public IEnumerable<Movimentacao> Movimentacoes { get; set; }
    }

}

