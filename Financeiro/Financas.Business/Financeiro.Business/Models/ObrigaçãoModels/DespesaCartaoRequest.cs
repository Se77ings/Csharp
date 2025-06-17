using System.ComponentModel.DataAnnotations;

namespace Financeiro.Business.Models.ObrigaçãoModels
{
	public class DespesaCartaoRequest
	{
		[Required]
		public string Descricao { get; set; }
		[Required]
		public decimal Total { get; set; }
		[Required]
		public DateTime DataVencimento { get; set; }
		[Required]
		public decimal SubTotal { get; set; }
		[Required]
		public decimal Descontos { get; set; } = 0;
		[Required]
		public string? Observacao { get; set; }

	}

	public class DespesaCartaoItemRequest
	{
		[Required]
		public string Descricao { get; set; }
		[Required]
		public decimal Total { get; set; }
		[Required]
		public DateTime DataVencimento { get; set; }
		[Required]
		public decimal SubTotal { get; set; }
		[Required]
		public decimal Descontos { get; set; } = 0;
		[Required]
		public string? Observacao { get; set; }
		public int ParcelaAtual { get; set; } = 1;
		public int QtdParcelas { get; set; } = 1;
	}
}
