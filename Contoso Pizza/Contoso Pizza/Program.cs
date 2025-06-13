using ContosoPizza.Models;
using ContosoPizza.Data;

using ContosoPizzaContext context = new ContosoPizzaContext();

// // Create (C)
// Product cheseeSpesial = new Product()
// {
//     Name = "Cheese Spesial Pizza",
//     Price = 10.9M
// };
// context.Products.Add(cheseeSpesial);

// Product ultimateMeat = new Product
// {
//     Name = "Ultimate Meat Pizza",
//     Price = 15.8M
// };
// context.Products.Add(ultimateMeat);

// context.SaveChanges();

// System.Console.WriteLine("Berhasil");

//READ (R)
var p = context.Products.First();
Console.WriteLine(p.Id);
var products = context.Products.Where
(products => products.Price > 10.0M).OrderBy(products => p.Name);

foreach (Product p in products)
{
    System.Console.WriteLine($"Id : {p.Id}");
    System.Console.WriteLine($"Name : {p.Name}");
    System.Console.WriteLine($"Price : {p.Price}");
    System.Console.WriteLine(new string ('-', 20));
}