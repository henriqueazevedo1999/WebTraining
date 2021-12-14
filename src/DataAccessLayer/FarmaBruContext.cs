using MetaData.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccessLayer
{
    public class FarmaBruContext : DbContext
    {
        public FarmaBruContext()
        {
        }

        public FarmaBruContext(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;
                                                    AttachDbFilename=C:\Users\Henrique\Documents\FarmaBruDB.mdf;
                                                    Integrated Security=True;Connect Timeout=5"
                                , x => x.EnableRetryOnFailure(3));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;
                                                    AttachDbFilename=C:\Users\Henrique\Documents\FarmaBruDB.mdf;
                                                    Integrated Security=True;Connect Timeout=5"
                                , x => x.EnableRetryOnFailure(3));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
