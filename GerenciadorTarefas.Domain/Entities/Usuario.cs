using GerenciadorTarefas.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public ICollection<Projeto>? Projetos { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}
