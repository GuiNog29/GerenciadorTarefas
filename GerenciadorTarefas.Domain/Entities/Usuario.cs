using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Tarefa? Tarefa { get; set; }
    }
}
