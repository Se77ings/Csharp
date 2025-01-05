using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList
{
    internal class Item
    {
        public string descricao { get; set; }
        public string valor { get; set; }
        public int prioridade { get; set; }

        public Item(string descricao, string valor, int prioridade)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.prioridade = prioridade;
        }

        public void exibeItens()
        {
            Console.WriteLine("Descrição: " + descricao);
            Console.WriteLine("Valor: " + valor);
            Console.WriteLine("Prioridade: " + prioridade);
        }
    }
}
