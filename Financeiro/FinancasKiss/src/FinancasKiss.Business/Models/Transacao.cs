
using FinancasKiss.Business.Models.DomainObjects;
using FinancasKiss.Business.Models.Tipos;

namespace FinancasKiss.Business.Models
{
    public class Transacao : Entity
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        public Demonstrativo Demonstrativo { get; private set; }

        public Transacao(string descricao, decimal valor, DateTime data, TipoTransacao tipo, Demonstrativo demonstrativo) : base(Guid.NewGuid())
        {
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;
            Data = data;
            Demonstrativo = demonstrativo;

            Validar();
        }

        public void Validar()
        {
            Validacao.ValidarSeNulo(Descricao, "O campo Descrição não pode ser nulo");
            Validacao.ValidarSeVazio(Descricao, "O campo Descrição não pode ser vazio");
            Validacao.ValidarSeIgual(Valor, 0, "O campo Valor não pode ser 0");
            Validacao.ValidarSeNulo(Data, "O campo Data não pode ser nulo");
        }

        /*
         Aparentemente, não preciso de nenhum Ad-Hoc Setter, a não ser que futuramente, eu precise alterar individualmente algum dos atributos, 
            o que acho que não deve acontecer
         */
    }
}
