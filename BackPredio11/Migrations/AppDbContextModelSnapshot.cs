﻿// <auto-generated />
using System;
using BackPredio11.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackPredio11.Entities.Retirada", b =>
                {
                    b.Property<long>("RetiradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RetiradaId"));

                    b.Property<DateTime>("DevolucaoData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LimiteData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeBem")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RetiradaData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RetiradaDescricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RetiradaId");

                    b.HasIndex("ItemId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Retiradas");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<long>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ItemId"));

                    b.Property<string>("ItemDescricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ItemPermitido")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeItem")
                        .HasColumnType("integer");

                    b.Property<string>("TipoItem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Pessoa", b =>
                {
                    b.Property<long>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PessoaId"));

                    b.Property<string>("PessoaIdUnivates")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PessoaNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PessoaSenha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PessoaTipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PessoaUsername")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Reserva", b =>
                {
                    b.Property<long>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ReservaId"));

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeBem")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReservaData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ReservaDataValidade")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReservaId");

                    b.HasIndex("ItemId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("BackPredio11.Entities.Retirada", b =>
                {
                    b.HasOne("Item", "Item")
                        .WithMany("Retiradas")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pessoa", "Pessoa")
                        .WithMany("Retiradas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Reserva", b =>
                {
                    b.HasOne("Item", "Item")
                        .WithMany("Reservas")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pessoa", "Pessoa")
                        .WithMany("Reservas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Navigation("Reservas");

                    b.Navigation("Retiradas");
                });

            modelBuilder.Entity("Pessoa", b =>
                {
                    b.Navigation("Reservas");

                    b.Navigation("Retiradas");
                });
#pragma warning restore 612, 618
        }
    }
}
