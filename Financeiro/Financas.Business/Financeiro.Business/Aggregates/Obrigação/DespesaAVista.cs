namespace Financeiro.Business.Aggregates.Obrigação
{
	public class DespesaAVista : ContasAPagar
	{
		// TODO não consegui pensar em nada mais pra ca
		/// EF Relation
		public Guid CompetenciaId { get; private set; }
		public Competencia Competencia { get; private set; }

		protected DespesaAVista() { }
		public DespesaAVista(string descricao, decimal subtotal, DateTime dataVencimento, decimal? descontos, string observacao) : base(descricao, subtotal, dataVencimento, descontos, observacao)
		{

		}
	}
}
