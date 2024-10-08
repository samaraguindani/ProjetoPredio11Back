﻿// <auto-generated />
using BackPredio11.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackPredio11.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240929214011_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.ToTable("Pessoas");
                });
#pragma warning restore 612, 618
        }
    }
}
