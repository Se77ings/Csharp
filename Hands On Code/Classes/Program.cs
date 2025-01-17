using System.Security.Cryptography.X509Certificates;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TrabalhandoComDatas();
            //Exceptions();
            //Console.WriteLine("Hello");
            //Arquivos();
            Linq();
        }
     
        private static void TrabalhandoComDatas()
        {
            var datas = new Datas.Datas();
            datas.SubtraindoDatas();
        }

        private static void Exceptions()
        {
            var exceptions = new Exceptions();
            exceptions.GerandoException();
        }

        private static void Arquivos()
        {
            var arquivos = new Arquivos();
            //arquivos.CriandoArquivos();
            //arquivos.LendoArquivos();
            arquivos.ExcluindoArquivos();
        }
    
        private static void Linq()
        {
            var aulaLinq = new LINQ();
            aulaLinq.AulaWhere();
        }
    }
}
