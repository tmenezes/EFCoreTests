using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        // constructor
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCoreTest1;Trusted_Connection=True;");
        }
    }
}