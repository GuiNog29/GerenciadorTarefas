using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaDbContext _context;
        private readonly ComentarioDbContext _comentarioContext;

        public TarefaRepository(TarefaDbContext context, ComentarioDbContext comentarioContext)
        {
            _context = context;
            _comentarioContext = comentarioContext;
        }

        public async Task<Tarefa> CadastrarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> AtualizarTarefa(Tarefa tarefa)
        {
            var tarefaExistente = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == tarefa.Id);
            if (tarefaExistente == null) 
                throw new KeyNotFoundException($"Tarefa com ID {tarefa.Id} não foi encontrada.");

            var prioridade = tarefaExistente.Prioridade;

            _context.Entry(tarefaExistente).CurrentValues.SetValues(tarefa);

            tarefaExistente.Prioridade = prioridade;

            await _context.SaveChangesAsync();
            return tarefaExistente;
        }

        public async Task<bool> ExcluirTarefa(int tarefaId)
        {
            var tarefa = await _context.Tarefas.FindAsync(tarefaId);
            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com ID {tarefaId} não foi encontrada.");

            if (tarefa.Comentarios != null && tarefa.Comentarios.Count != 0)
                _comentarioContext.Comentarios.RemoveRange(tarefa.Comentarios);

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefas(int projetoId)
        {
            var tarefas = await _context.Tarefas.Include(x => x.Comentarios).Where(x => x.ProjetoId == projetoId).ToListAsync();
            if (tarefas.Count == 0) 
                throw new Exception($"Não foi encontrado nenhuma tarefa no projeto, favor cadastrar novas tarefas.");

            return tarefas;
        }

        public async Task<Tarefa> VisualizarTarefa(int tarefaId)
        {
            var tarefa = await _context.Tarefas.Include(x => x.Comentarios).FirstOrDefaultAsync(x => x.Id == tarefaId);
            if(tarefa == null) 
                throw new KeyNotFoundException($"Tarefa com ID {tarefaId} não foi encontrada.");

            return tarefa;
        }
    }
}
