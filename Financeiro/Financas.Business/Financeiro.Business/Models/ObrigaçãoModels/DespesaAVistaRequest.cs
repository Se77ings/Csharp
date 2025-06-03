using System.ComponentModel.DataAnnotations;

namespace Financeiro.Business.Models.ObrigaçãoModels
{
	public class DespesaAVistaRequest
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
		public decimal Descontos { get; set; }
		[Required]
		public string? Observacao { get; set; }

	}
}
