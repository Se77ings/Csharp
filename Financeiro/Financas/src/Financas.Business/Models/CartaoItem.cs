using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Business.Models
{
    public class CartaoItem
    {
        // Inicialmente, eu pensei em colocar uma list<DateOnly> para registrar as faturas, porém, é melhor eu apenas guardar a data que foi passado... e montar uma lógica no
        // business para criar as próximas faturas. Bem como, preciso lembrar de instanciar uma fatura, caso ela não tenha sido instanciada ainda.
        public CartaoItem(string descricao, int numeroParcelas, DateOnly data, decimal valor)
        {
            Descricao = descricao;
            NumeroParcelas = numeroParcelas;
            Data = data;
            Valor = valor;
        
            
        }
        public string Descricao { get; set; }
        public int NumeroParcelas { get; set; }
        public DateOnly Data { get; set; }
        public decimal Valor { get; set; }
    }
}
