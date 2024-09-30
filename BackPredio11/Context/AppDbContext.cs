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
            modelBuilder.Entity<Retirada>()
                .HasOne(r => r.MotivoRetirada)
                .WithMany(mr => mr.Retiradas)
                .HasForeignKey(r => r.MotivoRetiradaId);
            
            //modelBuilder.Entity<Retirada>()
            //    .HasOne(r => r.Pessoa)
            //    .WithMany(p => p.Retiradas)
            //    .HasForeignKey(r => r.PessoaId);
            
            //modelBuilder.Entity<Reserva>()
            //    .HasOne(r => r.Pessoa)
            //    .WithMany(p => p.Reservas)
            //    .HasForeignKey(r => r.PessoaId);
            
            modelBuilder.Entity<Bem>()
                .HasOne(b => b.TipoBem)
                .WithMany(tb => tb.Bem)
                .HasForeignKey(b => b.TipoBemId);
            
            modelBuilder.Entity<Bem>()
                .HasOne(b => b.StatusBem)
                .WithMany(sb => sb.Bem)
                .HasForeignKey(b => b.StatusBemId);
            
            modelBuilder.Entity<ItensReserva>()
                .HasKey(ir => new { ir.BemId, ir.ReservaId });
            
            modelBuilder.Entity<ItensReserva>()
                .HasOne(ir => ir.Bem)
                .WithMany(b => b.ItensReserva) 
                .HasForeignKey(ir => ir.BemId);

            modelBuilder.Entity<ItensReserva>()
                .HasOne(ir => ir.Reserva)
                .WithMany(r => r.ItensReserva)  
                .HasForeignKey(ir => ir.ReservaId);
            
            modelBuilder.Entity<ItensRetirada>()
                .HasKey(ir => new { ir.RetiradaId, ir.BemId });

            modelBuilder.Entity<ItensRetirada>()
                .HasOne(ir => ir.Retirada)
                .WithMany(r => r.ItensRetirada)  
                .HasForeignKey(ir => ir.RetiradaId);
            
            modelBuilder.Entity<ItensRetirada>()
                .HasOne(ir => ir.Bem)
                .WithMany(b => b.ItensRetirada)  
                .HasForeignKey(ir => ir.BemId);
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<MotivoRetirada> Motivos { get; set; }
        public DbSet<Retirada> Retiradas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<StatusBem> StatusBem { get; set; }
        public DbSet<TipoBem> TipoBem { get; set; }
        public DbSet<Bem> Bem { get; set; }
        public DbSet<ItensReserva> ItensReserva { get; set; }
        public DbSet<ItensRetirada> ItensRetirada { get; set; }
    }
}
