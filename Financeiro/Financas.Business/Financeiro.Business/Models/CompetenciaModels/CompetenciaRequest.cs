using System.ComponentModel.DataAnnotations;

namespace Financeiro.Business.Models.CompetenciaModels
{
	public class CompetenciaRequest
	{
		[Required]
		public string Mes { get; private set; }
		[Required]
		public int Ano { get; private set; }

	}
}
