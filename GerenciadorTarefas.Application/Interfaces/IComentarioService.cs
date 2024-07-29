using GerenciadorTarefas.Application.DTOs;

namespace GerenciadorTarefas.Application.Interfaces
{
    public interface IComentarioService
    {
        Task<ComentarioDto> AdicionarComentario(ComentarioDto comentarioDto);
        Task<IEnumerable<ComentarioDto>> BuscarComentarios(int tarefaId);
    }
}
