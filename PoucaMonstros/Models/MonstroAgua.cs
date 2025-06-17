using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoucaMonstros.Models
{
	public class MonstroAgua : Monstro
	{
		public MonstroAgua(string nome, int atk, int def, int spd) : base(nome, atk, def, spd,TipoElemento.Agua )
		{
		}

		public override void AtaqueEspecial(Monstro alvo)
		{
			throw new NotImplementedException();
		}
	}
}
