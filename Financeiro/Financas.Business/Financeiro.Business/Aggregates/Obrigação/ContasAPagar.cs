namespace Financeiro.Business.Aggregates.Obrigação
{
	public abstract class ContasAPagar : Entidade
	{
		public string Descricao { get; private set; }
		public decimal Total { get; private set; }
		public DateTime DataVencimento { get; private set; }
		public decimal SubTotal { get; private set; }
		public decimal Descontos { get; private set; } = 0;
		public string? Observacao { get; private set; }


		protected ContasAPagar() { }

		public ContasAPagar(string descricao, decimal subtotal, DateTime dataVencimento, decimal? descontos, string observacao)
		{
			Descricao = descricao;
			SubTotal = subtotal;
			DataVencimento = dataVencimento;
			Descontos = descontos.HasValue ? descontos.Value : 0;
			Observacao = observacao;
			Total = SubTotal - Descontos;
		}
		public void Atualizar(string descricao, decimal subtotal, DateTime dataVencimento, decimal? descontos, string observacao)
		{
			Descricao = descricao;
			SubTotal = subtotal;
			DataVencimento = dataVencimento;
			Descontos = descontos.HasValue ? descontos.Value : 0;
			Observacao = observacao;
			Total = SubTotal - Descontos;
		}
	}
}
