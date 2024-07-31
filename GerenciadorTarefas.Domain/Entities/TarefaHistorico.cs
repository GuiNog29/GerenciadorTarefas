using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Domain.Entities
{
    public class TarefaHistorico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int TarefaId { get; set; }
        public required Tarefa Tarefa { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
        public required string Alteracao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
