using Swashbuckle.AspNetCore.Annotations;

namespace GerenciadorTarefas.Application.DTOs
{
    public class ComentarioDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime Data { get; set; }
        public required int TarefaId { get; set; }
    }
}
