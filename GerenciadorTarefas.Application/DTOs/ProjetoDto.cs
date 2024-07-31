using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorTarefas.Application.DTOs
{
    public class ProjetoDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public required string NomeProjeto { get; set; }
    }
}
