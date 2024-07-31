using GerenciadorTarefas.Application.DTOs;

namespace GerenciadorTarefas.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaDto> CadastrarTarefa(TarefaDto tarefaDto);
        Task<TarefaDto> VisualizarTarefa(int projetoId, int tarefaId);
        Task<TarefaDto> AtualizarTarefa(TarefaDto tarefaDto);
        Task<bool> ExcluirTarefa(int projetoId, int tarefaId);
        Task<IEnumerable<TarefaDto>> ListarTarefas(int projetoId);
    }
}
