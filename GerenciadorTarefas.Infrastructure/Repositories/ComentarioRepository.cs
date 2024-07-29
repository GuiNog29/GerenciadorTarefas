using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly ComentarioDbContext _context;
        public ComentarioRepository(ComentarioDbContext context)
        {
            _context = context;
        }

        public Task<Comentario> AdicionarComentario(Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comentario>> BuscarComentario(int tarefaId)
        {
            throw new NotImplementedException();
        }
    }
}
