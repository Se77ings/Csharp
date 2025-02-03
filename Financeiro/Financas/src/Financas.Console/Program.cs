using Financas.Business.Models;
using Financas.Business.Models.Tipos;

namespace Financas.Consol
{
    public class Program
    {
        static void Main(string[] args)
        {
            var minhaConta = new Conta("Itau", "341", "134164", "0298", 0, TipoConta.Corrente);

            var salario = new TransacaoAVista("Salario", 10000, DateTime.Now, TipoTransacao.Receita, minhaConta);

            var gasto1 = new TransacaoAVista("Aluguel", 1000, DateTime.Now, TipoTransacao.Despesa, minhaConta);
            var gasto2 = new TransacaoAVista("Mercado", 500, DateTime.Now, TipoTransacao.Despesa, minhaConta);

            var faturaJaneiro = new Fatura();
            faturaJaneiro.Transacoes.Add(salario);
            faturaJaneiro.Transacoes.Add(gasto1);
            faturaJaneiro.Transacoes.Add(gasto2);


            var inter = new TransacaoCartao("Inter", DateTime.Now, TipoTransacao.Despesa, minhaConta);
            inter.CartaoItens.Add(new CartaoItem("Netflix", 1, DateOnly.FromDateTime(DateTime.Now), 35.00m));
            inter.CartaoItens.Add(new CartaoItem("Spotify", 1, DateOnly.FromDateTime(DateTime.Now), 20.00m));
            inter.AtualizarValor();

            faturaJaneiro.Transacoes.Add(inter);
            Console.WriteLine(faturaJaneiro.ExibirFatura());
        }

    }
}
