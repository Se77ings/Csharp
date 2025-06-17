using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoucaMonstros.Models
{
	public abstract class Monstro
	{
		public Guid Id { get; private set; }
		public string? Nome { get; private set; }
		public int ATK { get; private set; }
		public int DEF { get; private set; }
		public int SPD { get; private set; }
		public int HP { get; private set; }
		public TipoElemento TipoElemento { get; protected set; }


		public int AtkBase { get; private set; }

		protected Monstro(string nome, int atk, int def, int spd, TipoElemento tipo)
		{
			Id = Guid.NewGuid();
			Nome = nome;
			ATK = atk;
			DEF = def;
			SPD = spd;
			HP = 100;
			TipoElemento = tipo;

			ValidaMonstro();
		}

		public void AtaqueBasico(Monstro alvo)
		{
			{

				var result = DanoElemento.CalcularMultiplicador(this.TipoElemento, alvo.TipoElemento);
				int dano;
				if (result.aplicadoEm == this.TipoElemento)
				{
					Console.WriteLine($"\t Vantagem é de {this.TipoElemento}, com {result.multi} de multiplicador no ATK");
					dano = (int)(this.ATK * result.multi - alvo.DEF);
				}
				else
				{
					Console.WriteLine($"\t Vantagem é de {alvo.TipoElemento}, com {result.multi} de multiplicador na DEF");

					dano = (int)(this.ATK - (result.multi * alvo.DEF));
				}
				if (dano < 0)
				{
					dano = 0;
				}

				alvo.RecebeDano(dano);
				Console.WriteLine($"{this.Nome} atacou {alvo.Nome} com {dano} de dano");
			}
		}


		public abstract void AtaqueEspecial(Monstro alvo);

		public void RecebeDano(int dano)
		{
			HP -= dano;
		}

		protected void ValidaMonstro()
		{
			if (ATK < 0 || DEF < 0 || SPD < 0)
			{
				throw new Exception("Atributos do monstro não podem ser negativos");
			}
		}

		public void ToConsole()
		{
			Console.WriteLine($"Nome: {Nome}, ATK: {ATK}, DEF: {DEF}, SPD: {SPD}, HP: {HP}");
		}
	}
}
