using EFCore_Learnings.Data;
using EFCore_Learnings.Models;

static void Main(string[] args)
{
    using ContosoPizzaContext context = new ContosoPizzaContext();
    Product veggieSpecial = new Product()
    {
        Name = "Veggie Special",
        Price = 12.99m
    };
    context.Products.Add(veggieSpecial);

    Product deluxeMeat = new Product()
    {
        Name = "Deluxe Meat",
        Price = 15.99m
    };
    context.Products.Add(deluxeMeat);
    context.SaveChanges();
}
