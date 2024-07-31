using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Infrastructure.Data
{
    public class GerenciadorTarefasDbContext : DbContext
    {
        public GerenciadorTarefasDbContext(DbContextOptions<GerenciadorTarefasDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TarefaHistorico> TarefaHistoricos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Projeto>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Projetos)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Projeto>()
                .HasMany(x => x.Tarefas)
                .WithOne(x => x.Projeto)
                .HasForeignKey(x => x.ProjetoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tarefa>()
                .HasMany(x => x.Comentarios)
                .WithOne(x => x.Tarefa)
                .HasForeignKey(x => x.TarefaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tarefa>()
                .HasMany(x => x.TarefaHistoricos)
                .WithOne(x => x.Tarefa)
                .HasForeignKey(x => x.TarefaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comentario>()
               .HasOne(x => x.Tarefa)
               .WithMany(x => x.Comentarios)
               .HasForeignKey(x => x.TarefaId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
