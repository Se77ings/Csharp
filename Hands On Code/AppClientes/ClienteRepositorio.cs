using Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ClienteRepositorio
    {
        public List<Cliente> clientes = new List<Cliente>();

        public void ImprimirCliente(Cliente cliente)
        {
            Console.WriteLine("ID.............: " + cliente.ID);
            Console.WriteLine("Nome...........: " + cliente.Nome);
            Console.WriteLine("Desconto.......: " + cliente.Desconto.ToString("0.00"));
            Console.WriteLine("Data Nascimento: " + cliente.DataNascimento);
            Console.WriteLine("Data Cadastro..: " + cliente.CadastradoEm);
            Console.WriteLine("--------------------------------");


        }

        public void ExibirClientes()
        {
            Console.Clear();
            foreach (var cliente in clientes)
            {
                ImprimirCliente(cliente);
            }

            Console.WriteLine("[Pressione enter para continuar]");
            Console.ReadKey();
            return;
        }

        public void CadastrarCliente()
        {
            Console.Clear();
            Console.Write("Digite o Nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write(Environment.NewLine);

            Console.Write("Digite a data de Nascimento: ");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            Console.Write("Digite o desconto aplicado para este cliente: ");
            var desconto = decimal.Parse(Console.ReadLine());



            var cliente = new Cliente();
            cliente.ID = clientes.Count() + 1;
            cliente.Nome = nome;
            cliente.Desconto = desconto;
            cliente.DataNascimento = dataNascimento;
            cliente.CadastradoEm = DateTime.Now;

            clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso");
            ImprimirCliente(cliente);
            Console.Write(Environment.NewLine);
            Console.WriteLine("[Pressione enter para continuar]");
            Console.ReadKey();
            return;

        }

        public void EditarCliente()
        {
            Console.Clear();
            Console.Write("Informe o código do cliente");
            var codigo = Console.ReadLine();

            var cliente = clientes.FirstOrDefault(p => p.ID == int.Parse(codigo));

            if (cliente == null)
            {
                Console.Write("Cliente não encontrado.... [Enter]");
                Console.ReadKey();
                return;
            }

            ImprimirCliente(cliente);

            Console.Write("Nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write(Environment.NewLine);

            Console.Write("Data de nasicmento: ");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            Console.Write("Desconto:");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.Write(Environment.NewLine);

            cliente.Nome = nome;
            cliente.Desconto = desconto;
            cliente.DataNascimento = dataNascimento;
            cliente.CadastradoEm = DateTime.Now;

            Console.Write("Cliente alterado com sucesso! [Enter]");
            ImprimirCliente(cliente);
            Console.ReadKey();


        }

        public void ExcluirCliente()
        {
            Console.Clear();
            Console.Write("Digite o código do cliente que deseja deletar: ");
            var codigo = Console.ReadLine();

            var cliente = clientes.FirstOrDefault(p => p.ID == int.Parse(codigo));

            if (cliente == null)
            {
                Console.Write("Cliente não encontrado.... [Enter]");
                Console.ReadKey();
                return;
            }


            ImprimirCliente(cliente);

            clientes.Remove(cliente);
            Console.Write("Cliente removido com Sucesso! [Enter]");
            Console.ReadKey();
        }
    }
}
