namespace WishList
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
            //Application.Run(new Form1());

            //itemTeste.exibeItens();

            Arquivo arquivo = new Arquivo();
            
            arquivo.leArquivo();
        }
    }
}