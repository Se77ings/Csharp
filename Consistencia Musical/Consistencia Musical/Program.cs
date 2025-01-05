using System.Text.Json;

namespace Consistencia_Musical
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var AUTO_INCREMENT = 0;

            Application.Run(new Form1());
            new AdicionarMusica().Visible = false;
            //Musica nova = new Musica(0, "Life could be a dream", "idk", 50, "https://youtube.com");
            //nova.exibeMusica();

            ListaMusicas.Listar();

            //Musica musicas = JsonSerializer.Deserialize<Musica>(linha);
            //musicas.exibeMusica();

        }
    }
}