﻿// <auto-generated />
using System;
using GerenciadorTarefas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciadorTarefas.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeProjeto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("GerenciadorTarefas.Domain.Entities.Tarefa", "Tarefa")
                        .WithMany("Comentarios")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Tarefa", b =>
                {
                    b.HasOne("GerenciadorTarefas.Domain.Entities.Projeto", "Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Projeto", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("GerenciadorTarefas.Domain.Entities.Tarefa", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}