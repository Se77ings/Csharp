using FinancasKiss.Business.Models.Tipos;

namespace FinancasKiss.Business.Models
{
    public class Demonstrativo : Entity
    {
        public int Mes { get; private set; }
        public List<Transacao> Transacoes { get; private set; }

        public Demonstrativo(int mes, List<Transacao>? transacoes = null) : base(Guid.NewGuid())
        {
            Mes = mes;
            Transacoes = transacoes ?? new List<Transacao>();
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            Transacoes.Add(transacao);
        }

        public void RemoverTransacao(Transacao transacao)
        {
            Transacoes.Remove(transacao);
        }

        public decimal ObterTotalTransacoes()
        {
            var positivas = Transacoes.Sum(t=> t.Tipo == TipoTransacao.Receita ? t.Valor : 0);
            var negativas = Transacoes.Sum(t=> t.Tipo == TipoTransacao.Despesa ? t.Valor : 0);
            return positivas - negativas;

        }
    }
}
