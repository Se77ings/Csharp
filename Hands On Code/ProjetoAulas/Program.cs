using System.Reflection.Metadata.Ecma335;

namespace ProjetoAulas;
public class Program
{
    private static void Main(string[] args)
    {
        var controle = foo();

        Console.WriteLine(controle.ToString());



        string foo()
        {
            var value = Task.WaitAny(Task.Run(() =>
            {
                Console.WriteLine("in");
                Task.Delay(1100).ContinueWith(x => Console.WriteLine("teste 2"));

            }));

            Console.WriteLine(value.ToString());
            Console.WriteLine(value);
            while (value != 0)
            {
                if (value != 0) { Console.WriteLine("ok"); return "OK"; }
            }
            return "BAD";
        }
    }

}