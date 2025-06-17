namespace MinhaApp.Business.Models
{
	public class Produto : Entity
	{
		public string? Nome { get; set; }
		public string? Descricao { get; set; }
		public decimal Valor { get; set; }
		public DateTime DataCadastro { get; set; }
		public string? Imagem { get; set; }
		public bool Ativo { get; set; }
		/* EF Relations */
		public Fornecedor Fornecedor { get; set; }
		public Guid FornecedorId { get; set; }

		protected Produto() { }
	}
}
