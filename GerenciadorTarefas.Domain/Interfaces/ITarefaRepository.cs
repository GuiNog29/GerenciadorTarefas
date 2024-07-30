using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa> CadastrarTarefa(Tarefa tarefa);
        Task<Tarefa> VisualizarTarefa(int tarefaId);
        Task<bool> ExcluirTarefa(int tarefaId);
        Task<Tarefa> AtualizarTarefa(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> ListarTarefas(int projetoId);
        Task<IEnumerable<RelatorioDesempenhoUsuario>> GerarRelatorioDesempenhoUsuario(int usuarioId);
    }
}
