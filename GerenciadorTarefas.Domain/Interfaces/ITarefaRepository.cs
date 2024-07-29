using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa> CadastrarTarefa(Tarefa tarefa);
        Task<Tarefa> VisualizarTarefa(int tarefaId);
        Task<string> ExcluirTarefa(int tarefaId);
        Task<string> AtualizarProjeto(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> ListarTarefas(int projetoId);
    }
}
