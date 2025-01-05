using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consistencia_Musical
{
    internal class Musica
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string artista { get; set; }
        private int _aprendizado;
        public int aprendizado
        {
            get { return _aprendizado; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Valor de aprendizado inválido. Deve estar entre 0 e 100.");
                }
                _aprendizado = value;
            }
        }
        public string link;

        public Musica(int id, string nome, string artista, int aprendizado, string link)
        {
            this.id = id;
            this.nome = nome;
            this.artista = artista;
            this.aprendizado = aprendizado;
            this.link = link;
        }

        public Musica(){}

        public void exibeMusica()
        {
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Artista: " + artista);
            Console.WriteLine("Aprendizado: " + aprendizado+"%");
            Console.WriteLine("Link da aula: " + this.link);
        }
    }
}
