using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }

        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Produto(string nome, string descricao, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, int quantidadeEstoque, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            CategoriaId = categoriaId;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
            Ativo = true;
            Dimensoes = dimensoes;

            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacao.ValidarSeVazio(Nome, "O camp Nome do produto não pode estar vazio");
            Validacao.ValidarSeVazio(Descricao, "O campo Descrição do produto não pode estar vazio");
            Validacao.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode estar vazio");
            Validacao.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode ser menor ou igual a 0");
            Validacao.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
            
        }
    }
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Validar();

        }

        public void Validar()
        {
            Validacao.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacao.ValidarSeIgual(Codigo, 0, "O campo Código da categoria não pode ser 0");
        }
    }
}
