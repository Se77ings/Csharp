using System.ComponentModel.DataAnnotations;

namespace Financeiro.Business.Models.DireitoModels
{
	public class ContasAReceberRequest
	{
		[Required]
		public string Descricao { get; private set; }
		[Required]
		public decimal SubTotal { get; private set; }
		[Required]
		public decimal Descontos { get; private set; }
		[Required]
		public decimal Total { get; private set; }
		[Required]
		public DateTime Data { get; private set; }

	}
}
