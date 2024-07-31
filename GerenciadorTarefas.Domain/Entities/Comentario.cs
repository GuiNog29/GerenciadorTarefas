using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime Data { get; set; }
        [Required]
        public required int TarefaId { get; set; }
        public required Tarefa Tarefa { get; set; }
    }
}
