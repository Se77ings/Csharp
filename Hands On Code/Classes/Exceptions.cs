using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Exceptions
    {
        public void GerandoException()
        {
            while (true)
            {
                Console.WriteLine("Informe um número");
                var digitado = Console.ReadLine();
                try
                {

                    Console.WriteLine("Resultado -> " + 500 / int.Parse(digitado));
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    Console.WriteLine("Tente novamente");
                }
                //break;
            }
        }
    }
}
