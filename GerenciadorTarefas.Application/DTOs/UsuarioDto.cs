using GerenciadorTarefas.Domain.Enums;

namespace GerenciadorTarefas.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
