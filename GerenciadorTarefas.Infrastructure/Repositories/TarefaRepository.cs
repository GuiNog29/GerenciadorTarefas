using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaDbContext _context;
        public TarefaRepository(TarefaDbContext context)
        {
            _context = context;
        }

        public Task<string> AtualizarProjeto(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> CadastrarTarefa(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExcluirTarefa(int tarefaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> ListarTarefas(int projetoId)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> VisualizarTarefa(int tarefaId)
        {
            throw new NotImplementedException();
        }
    }
}
