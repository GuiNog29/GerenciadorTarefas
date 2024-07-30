using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly GerenciadorTarefasDbContext _context;

        public ComentarioRepository(GerenciadorTarefasDbContext context)
        {
            _context = context;
        }

        public async Task<Comentario> AdicionarComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task<IEnumerable<Comentario>> BuscarComentarios(int tarefaId)
        {
            var comentarios = await _context.Comentarios.Where(x => x.TarefaId == tarefaId).ToListAsync();
            if (comentarios.Count == 0)
                throw new Exception($"Não foi encontrado nenhum comentário para esta tarefa, favor adicionar novos comentários.");
             
            return comentarios;
        }
    }
}
