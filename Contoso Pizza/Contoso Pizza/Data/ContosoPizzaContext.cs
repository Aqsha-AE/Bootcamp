//DBContext as respresenting asession within the database

using ContosoPizza.Models; 
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;
//DBSet maps to a table that will be cretead in the database 
public class ContosoPizzaContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> Details { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Pizza.db");
    }

}
    