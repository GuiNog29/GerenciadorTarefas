using GerenciadorTarefas.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public Status Status { get; set; }
        [Required]
        public required Prioridade Prioridade { get; set; }

        public int ProjetoId { get; set; }
        public required Projeto Projeto { get; set; }

        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        public ICollection<Comentario>? Comentarios { get; set; }
        public ICollection<TarefaHistorico>? TarefaHistoricos { get; set; }
    }
}
