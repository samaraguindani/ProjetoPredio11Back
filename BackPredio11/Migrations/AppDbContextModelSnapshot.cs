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

            modelBuilder.Entity("BackPredio11.Entities.Bem", b =>
                {
                    b.Property<long>("BemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BemId"));

                    b.Property<string>("BemDescricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BemPermitido")
                        .HasColumnType("integer");

                    b.Property<long>("StatusBemId")
                        .HasColumnType("bigint");

                    b.Property<long>("TipoBemId")
                        .HasColumnType("bigint");

                    b.HasKey("BemId");

                    b.HasIndex("StatusBemId");

                    b.HasIndex("TipoBemId");

                    b.ToTable("Bem", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.ItensReserva", b =>
                {
                    b.Property<long>("BemId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReservaId")
                        .HasColumnType("bigint");

                    b.Property<string>("QuantidadeBem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BemId", "ReservaId");

                    b.HasIndex("ReservaId");

                    b.ToTable("ItensReserva", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.ItensRetirada", b =>
                {
                    b.Property<long>("RetiradaId")
                        .HasColumnType("bigint");

                    b.Property<long>("BemId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeBem")
                        .HasColumnType("integer");

                    b.HasKey("RetiradaId", "BemId");

                    b.HasIndex("BemId");

                    b.ToTable("ItensRetirada", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.MotivoRetirada", b =>
                {
                    b.Property<long>("MotivoRetiradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("MotivoRetiradaId"));

                    b.Property<string>("MotivoDescricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MotivoRetiradaId");

                    b.ToTable("Motivos", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.Pessoa", b =>
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

                    b.Property<string>("PessoaTipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.Reserva", b =>
                {
                    b.Property<long>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ReservaId"));

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.Property<int>("QuantidadeBem")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReservaData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ReservaDataValidade")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReservaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Reservas", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.Retirada", b =>
                {
                    b.Property<long>("RetiradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("RetiradaId"));

                    b.Property<DateTime>("DevolucaoData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LimiteData")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("MotivoRetiradaId")
                        .HasColumnType("bigint");

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

                    b.HasIndex("MotivoRetiradaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Retiradas", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.StatusBem", b =>
                {
                    b.Property<long>("StatusBemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("StatusBemId"));

                    b.Property<string>("StatusNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("StatusBemId");

                    b.ToTable("StatusBem", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.TipoBem", b =>
                {
                    b.Property<long>("TipoBemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TipoBemId"));

                    b.Property<string>("TipoNome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TipoBemId");

                    b.ToTable("TipoBem", (string)null);
                });

            modelBuilder.Entity("BackPredio11.Entities.Bem", b =>
                {
                    b.HasOne("BackPredio11.Entities.StatusBem", "StatusBem")
                        .WithMany("Bem")
                        .HasForeignKey("StatusBemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackPredio11.Entities.TipoBem", "TipoBem")
                        .WithMany("Bem")
                        .HasForeignKey("TipoBemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusBem");

                    b.Navigation("TipoBem");
                });

            modelBuilder.Entity("BackPredio11.Entities.ItensReserva", b =>
                {
                    b.HasOne("BackPredio11.Entities.Bem", "Bem")
                        .WithMany("ItensReserva")
                        .HasForeignKey("BemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackPredio11.Entities.Reserva", "Reserva")
                        .WithMany("ItensReserva")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bem");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("BackPredio11.Entities.ItensRetirada", b =>
                {
                    b.HasOne("BackPredio11.Entities.Bem", "Bem")
                        .WithMany("ItensRetirada")
                        .HasForeignKey("BemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackPredio11.Entities.Retirada", "Retirada")
                        .WithMany("ItensRetirada")
                        .HasForeignKey("RetiradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bem");

                    b.Navigation("Retirada");
                });

            modelBuilder.Entity("BackPredio11.Entities.Reserva", b =>
                {
                    b.HasOne("BackPredio11.Entities.Pessoa", "Pessoa")
                        .WithMany("Reservas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BackPredio11.Entities.Retirada", b =>
                {
                    b.HasOne("BackPredio11.Entities.MotivoRetirada", "MotivoRetirada")
                        .WithMany("Retiradas")
                        .HasForeignKey("MotivoRetiradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackPredio11.Entities.Pessoa", "Pessoa")
                        .WithMany("Retiradas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MotivoRetirada");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BackPredio11.Entities.Bem", b =>
                {
                    b.Navigation("ItensReserva");

                    b.Navigation("ItensRetirada");
                });

            modelBuilder.Entity("BackPredio11.Entities.MotivoRetirada", b =>
                {
                    b.Navigation("Retiradas");
                });

            modelBuilder.Entity("BackPredio11.Entities.Pessoa", b =>
                {
                    b.Navigation("Reservas");

                    b.Navigation("Retiradas");
                });

            modelBuilder.Entity("BackPredio11.Entities.Reserva", b =>
                {
                    b.Navigation("ItensReserva");
                });

            modelBuilder.Entity("BackPredio11.Entities.Retirada", b =>
                {
                    b.Navigation("ItensRetirada");
                });

            modelBuilder.Entity("BackPredio11.Entities.StatusBem", b =>
                {
                    b.Navigation("Bem");
                });

            modelBuilder.Entity("BackPredio11.Entities.TipoBem", b =>
                {
                    b.Navigation("Bem");
                });
#pragma warning restore 612, 618
        }
    }
}
