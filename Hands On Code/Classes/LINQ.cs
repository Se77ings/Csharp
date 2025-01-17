
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class LINQ
    {
        public void AulaWhere()
        {
            string nomeCompleto = "GABRIEL FERNANDES";
            /*
            // 1ª forma
            Func<char, bool> filtro = c => c == 'A';
            //var resultado = nomeCompleto.Where(filtro);

            // 2ª forma
            //var resultado = nomeCompleto.Where(p => p == 'A');

            //3ª forma
            var resultado = from c in nomeCompleto where c == 'E' select c;
            
            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }*/


            var numeros = new int[] { 5, 12, 6, 32, 1, 12 };

            //var acima10 = numeros.Where(p => p > 10).OrderByDescending(p =>p);

            //foreach(var item in acima10)
            //{
            //    Console.WriteLine(item);
            //}

            var primeiroOuDefault = numeros.FirstOrDefault(p => p >= 130);
            //Console.WriteLine(primeiroOuDefault);

            var single = numeros.SingleOrDefault(p => p == 12,-5);

            Console.WriteLine(single);
        }
    }
}
