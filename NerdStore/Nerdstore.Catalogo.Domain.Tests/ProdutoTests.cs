using NerdStore.Catalogo.Domain;

namespace Nerdstore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {

            // Arrange & Act & Assert

            //public Produto(string nome, string descricao, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, int quantidadeEstoque, Dimensoes dimensoes)


            var ex = Assert.Throws<DomainException>(() =>
                
                new Produto(string.Empty, "Desc", 100.00m,DateTime.Now, "asd", 1, new Dimensoes(1,1,1))

            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", string.Empty,  100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao",  0, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Valor do produto não pode se menor igual a 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao",  100, Guid.Empty, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo CategoriaId do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao",  100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensoes(1, 1, 1))
            );

            Assert.Equal("O campo Imagem do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", "Descricao",  100, Guid.NewGuid(), DateTime.Now, "Imagem", new Dimensoes(0, 1, 1))
            );

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }
    }
}