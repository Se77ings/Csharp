using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoucaMonstros.Models
{
	public class DanoElemento
	{
		public static readonly Dictionary<(TipoElemento atacante, TipoElemento defensor), (double multi, TipoElemento aplicadoEm)> Multiplicadores =
			new() {
				#region Ataque Agua
				{(TipoElemento.Agua, TipoElemento.Agua), (0, TipoElemento.Agua)},
				{(TipoElemento.Agua, TipoElemento.Fogo), (2, TipoElemento.Agua)},
				{(TipoElemento.Agua, TipoElemento.Terra), (2, TipoElemento.Terra)},
				#endregion
				#region Ataque Fogo
				{(TipoElemento.Fogo, TipoElemento.Agua), (3, TipoElemento.Agua)},
				{(TipoElemento.Fogo, TipoElemento.Fogo) , (0, TipoElemento.Fogo) },
				{(TipoElemento.Fogo, TipoElemento.Terra) , (.5, TipoElemento.Terra)},
				#endregion
				#region Ataque Terra 
				{(TipoElemento.Terra, TipoElemento.Agua) , (3, TipoElemento.Terra)},
				{(TipoElemento.Terra, TipoElemento.Fogo) , (2, TipoElemento.Terra)},
				{(TipoElemento.Terra, TipoElemento.Terra) , (4, TipoElemento.Terra)},
				#endregion
				//TODO: Continuar a partir daqui
			};

		public static (double multi,TipoElemento aplicadoEm) CalcularMultiplicador(TipoElemento atacante, TipoElemento defensor)
		{
			return Multiplicadores[(atacante, defensor)];
		}

	}


}
