using Entity_Framework.Data;
using Entity_Framework.Models;
using Entity_Framework.Services;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Entity Framework Core Demo ===");

            using var context = new CompanyDbContext();
            
            // Apply migrations
            await context.Database.MigrateAsync();
            
            // Seed data
            await SeedDatabaseAsync(context);

            // Initialize services
            var employeeService = new EmployeeService(context);

            // Demo CRUD operations
            await DemonstrateCrudOperationsAsync(employeeService);
        }

        private static async Task DemonstrateCrudOperationsAsync(EmployeeService employeeService)
        {
            throw new NotImplementedException();
        }

        static async Task SeedDatabaseAsync(CompanyDbContext context)
        {
            if (await context.Departments.AnyAsync()) return;

            var departments = new[]
            {
                new Department { Name = "Engineering", Description = "Software development", Budget = 500000m },
                new Department { Name = "Sales", Description = "Revenue generation", Budget = 300000m },
                // ... more departments
            };
            
            context.Departments.AddRange(departments);
            await context.SaveChangesAsync();

            // Add employees and projects similarly...
        }
    }
}