using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Projeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string NomeProjeto { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}
