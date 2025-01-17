using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Arquivos
    {
        public void CriandoArquivos()
        {
            var escrever = new StreamWriter("registro.txt", true); //cria uma conexão
            Console.WriteLine("Informe um nome: ");
            var nome = Console.ReadLine();

            escrever.WriteLine("ID ....."+ Random.Shared.Next(1, 100));
            escrever.WriteLine("Nome ..."+ nome);
            escrever.WriteLine("=========================");

            escrever.Close(); //fecha a conexão
        }

        public void LendoArquivos()
        {
            //forma mais fácil:
            var conteudo = File.ReadAllText("registro.txt");
            //Console.WriteLine(conteudo);



            // forma mais completa:
            var leitor = new StreamReader("registro.txt");
            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
        }

        public void ExcluindoArquivos()
        {
            if (File.Exists("registro.txt"))
            {
                File.Delete("registro.txt");
            }
            else
            {
                Console.WriteLine("doesn't exists");
            }
        }
    }
}
