using System;
using System.Collections.Generic;
using CursoEFCore.Domain;
using CursoEFCore.ValueObjects;
using Microsoft.EntityFrameworkCore;
namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Data.ApplicationContext();
            var existe = db.Database.GetPendingMigrations().Any();
            //Console.WriteLine(existe);
            //InserirDados();
            //InserirDadosEmMassa();
            //ConsultaDados();
            //CadastrarPedido();
            //AtualizarDados();
            RemoverRezistros();

        }

        public static void RemoverRezistros()
        {
            using var db = new Data.ApplicationContext();   
            //var cliente = db.Clientes.Find(2); // aqui ele faz 2 consultas, uma para buscar o cliente e outra para deletar

            var cliente = new Cliente { Id = 3 }; // assim faz apenas 1 consulta, e apenas deleta direto

            db.Remove(cliente);

            db.SaveChanges();
        }
        public static void AtualizarDados()
        {
            using var db = new Data.ApplicationContext();

            //var cliente = db.Clientes.FirstOrDefault(p=> p.Id == 1);
            var cliente = db.Clientes.Find(1);
            cliente.Nome = "Novo nome do cliente";
            //db.Clientes.Update(cliente); // esse metodo sobrescreve todas as colunas
            //sem ele, vai alterar no banco apenas o campo alterado
            db.SaveChanges();

        }
        public static void ConsultarPedidoCarregamentoAdiantado()
        {

            using var db = new Data.ApplicationContext();
            var pedidos = db.Pedidos.Include(p => p.Itens).ThenInclude(p => p.Produto).ToList();

            Console.WriteLine(pedidos.Count);
        }
        public static void CadastrarPedido()
        {
            var db = new Data.ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                TipoFrete = TipoFrete.SemFrete,
                Status = StatusPedido.Analise,
                Observacao = "Pedido de teste",
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = produto.Valor
                    }
                }
            };
            db.Pedidos.Add(pedido);
            db.SaveChanges();

        }
        public static void ConsultaDados()
        {
            var db = new Data.ApplicationContext();

            //var consultaPorSintaxe = (from kkk in db.Clientes where kkk.Id > 0 select kkk).ToList();
            var consultaPorMetodo = db.Clientes.Where(p => p.Id > 0).ToList().OrderBy(p => p.Id); // -> Dessa forma, os dados consultados são armazenados em memória, fazendo com que consulte mais rapido nas proximas vezes
            //var consultaPorMetodo = db.Clientes.Where(p => p.Id > 0).AsNoTracking().ToList();

            foreach (var cliente in consultaPorMetodo)
            {
                //db.Clientes.Find(cliente.Id); // apenas esse metodo Find, consegue verificar os dados armazenados em memória
                db.Clientes.FirstOrDefault(p => p.Id == cliente.Id);
                Console.WriteLine($"Consultando o cliente {cliente.Nome}");
            }
        }
        public static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234392891234",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "Fulano de Tal",
                CEP = "99999999",
                Cidade = "Cidade Teste",
                Estado = "TE",
                Telefone = "999999999"

            };
            using var db = new Data.ApplicationContext();
            //db.AddRange(produto, cliente);

            var listaClientes = new[] {
                new Cliente
                {
                    Nome = "Cliente 1",
                    CEP = "99999999",
                    Cidade = "Cidade Teste",
                    Estado = "TE",
                    Telefone = "999999999"
                },
                new Cliente
                {
                    Nome = "Cliente 2",
                    CEP = "99999999",
                    Cidade = "Cidade Teste",
                    Estado = "TE",
                    Telefone = "999999999"
                }
            };

            db.AddRange(listaClientes);
            var rezistros = db.SaveChanges();

            Console.WriteLine($"Total Rezistro(s): {rezistros}");

        }

        public static void InserirDados()
        {
            var produto = new Produto
            {
                Descricao = "Produto Teste",
                CodigoBarras = "1234567891234",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();

            db.Produtos.Add(produto);

            var rezistros = db.SaveChanges();

            Console.WriteLine($"Total Rezistro(s): {rezistros}");
        }
    }
}