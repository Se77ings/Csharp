using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public ICollection<Produto> Produtos { get; private set; }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
        //EF tem problemas para popular classes sem construtor vazio
        public Categoria()
        {
            
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
