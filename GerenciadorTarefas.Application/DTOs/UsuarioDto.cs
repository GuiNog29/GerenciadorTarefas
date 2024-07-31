using GerenciadorTarefas.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace GerenciadorTarefas.Application.DTOs
{
    public class UsuarioDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
