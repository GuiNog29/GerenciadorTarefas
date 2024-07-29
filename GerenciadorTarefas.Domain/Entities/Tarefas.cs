using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Status { get; set; }
        public required Prioridade Prioridade { get; set; }

        public int ProjetoId { get; set; }
        public required Projeto Projeto { get; set; }

        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
