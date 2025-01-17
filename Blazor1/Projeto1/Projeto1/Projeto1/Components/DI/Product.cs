namespace Projeto1.Components.DI
{

    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }

    public class ProductService : IProductService
    {
        public async Task<List<Product>> GetProductsAsync()
        {
            return new List<Product>
            {
                new Product {Id= 1, Name= "Produto A", Price= 100},
                new Product {Id= 2, Name= "Produto B", Price= 150},
                new Product {Id= 3, Name= "Produto C", Price= 200}
            };
        }
    }
}
