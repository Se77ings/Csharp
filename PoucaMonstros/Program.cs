using PoucaMonstros.Models;

namespace PoucaMonstros
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var Danudo = new MonstroFogo("Danudo", 80, 50, 45);
			var Rapidola = new MonstroAgua("Rapidola", 68, 45, 70);
			var Defesudo = new MonstroTerra("Defesudo", 60, 90, 50);

			Danudo.ToConsole();
			Rapidola.ToConsole();
			Danudo.AtaqueBasico(Rapidola);
			Rapidola.ToConsole();

			Rapidola.AtaqueBasico(Danudo);
			Danudo.ToConsole();

		}
	}
}

