using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

using Challenge.Full.Stack.WebDev.Models;

namespace Challenge.Full.Stack.WebDev.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            try
            {
                Database.EnsureCreated();  // Crea la base de datos si no existe
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        }
    }
