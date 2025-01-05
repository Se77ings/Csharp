using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList
{
    internal class Arquivo
    {
        public List<Item> itens = new List<Item>();

        public void gravaArquivo(List<Item> itens)
        {
            StreamWriter sw = new StreamWriter("./arquivo.txt");
            foreach (Item item in itens)
            {
                sw.WriteLine(item.descricao + "þ" + item.valor + "þ" + item.prioridade);
            }
            sw.Close();
        }

        public void leArquivo()
        {
            StreamReader sr = new StreamReader("./arquivo.txt");
            string linha = sr.ReadLine();
            while (linha != null)
            {
                string[] dados = linha.Split('þ');
                Item item = new Item(dados[0], dados[1], int.Parse(dados[2]));
                itens.Add(item);
                linha = sr.ReadLine();
            }
            sr.Close();
            gravaArquivo(itens);
        }
    }
}
