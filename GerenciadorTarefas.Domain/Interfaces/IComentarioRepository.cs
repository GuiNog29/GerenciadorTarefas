using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface IComentarioRepository
    {
        Task<Comentario> AdicionarComentario(Comentario comentario);
        Task<IEnumerable<Comentario>> BuscarComentario(int tarefaId);
    }
}
