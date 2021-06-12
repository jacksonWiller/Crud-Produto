using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace ProAgil.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Produto> Produtos {get;set;}
    
    }
}