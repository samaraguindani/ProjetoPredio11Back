using Microsoft.EntityFrameworkCore;
using BackPredio11.Entities;

namespace BackPredio11.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Definindo os DbSets para as entidades
        public DbSet<Item> Items { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Retirada> Retiradas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações para a entidade Item
            modelBuilder.Entity<Item>()
                .HasKey(i => i.ItemId); // Chave primária

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Reservas)
                .WithOne(r => r.Item)
                .HasForeignKey(r => r.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Retiradas)
                .WithOne(r => r.Item)
                .HasForeignKey(r => r.ItemId)
                .OnDelete(DeleteBehavior.Cascade);


            // Configurações para a entidade Pessoa
            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.PessoaId); // Chave primária

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Retiradas)
                .WithOne(r => r.Pessoa)
                .HasForeignKey(r => r.PessoaId)
                .OnDelete(DeleteBehavior.Cascade); // Configuração de relacionamento com Retirada

            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Reservas)
                .WithOne(r => r.Pessoa)
                .HasForeignKey(r => r.PessoaId)
                .OnDelete(DeleteBehavior.Cascade); // Configuração de relacionamento com Reserva

            // Configurações para a entidade Reserva
            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.ReservaId); // Chave primária

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Pessoa)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.PessoaId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Reservas)
                .HasForeignKey(r => r.ItemId);

            // Configurações para a entidade Retirada
            modelBuilder.Entity<Retirada>()
                .HasKey(r => r.RetiradaId); // Chave primária

            modelBuilder.Entity<Retirada>()
                .HasOne(r => r.Pessoa)
                .WithMany(p => p.Retiradas)
                .HasForeignKey(r => r.PessoaId);

            modelBuilder.Entity<Retirada>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Retiradas)
                .HasForeignKey(r => r.ItemId);
        }
    }
}
