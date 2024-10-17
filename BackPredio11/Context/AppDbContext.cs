using BackPredio11.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackPredio11.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<MotivoRetirada> Motivos { get; set; }
        public DbSet<Retirada> Retiradas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<StatusItem> StatusItems { get; set; }
        public DbSet<TipoItem> TipoItems { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
