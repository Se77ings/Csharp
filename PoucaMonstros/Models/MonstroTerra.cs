using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoucaMonstros.Models
{
	public class MonstroTerra : Monstro
	{
		
		public MonstroTerra(string nome, int atk, int def, int spd) : base(nome, atk, def, spd, TipoElemento.Terra)
		{
		}

		public override void AtaqueEspecial(Monstro alvo)
		{
			throw new NotImplementedException();
		}
	}
}
