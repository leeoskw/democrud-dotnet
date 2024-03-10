using democrud.models.ComercioModels;
using Microsoft.EntityFrameworkCore;

namespace democrud.DataContext
{
    public class ComercioContext : DbContext
    {
        public ComercioContext(DbContextOptions<ComercioContext> options) : base(options) 
        { 
        }

        //criar tabelas

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Venda> Venda { get; set; } 
    }
}
