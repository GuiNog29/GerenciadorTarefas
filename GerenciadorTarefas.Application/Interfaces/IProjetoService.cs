using GerenciadorTarefas.Application.DTOs;

namespace GerenciadorTarefas.Application.Interfaces
{
    public interface IProjetoService
    {
        Task<ProjetoDto> CadastrarProjeto(ProjetoDto projetoDto);
        Task<ProjetoDto> VisualizarProjeto(int projetoId);
        Task<bool> ExcluirProjeto(int projetoId);
        Task<IEnumerable<ProjetoDto>> ListarProjetos();
    }
}
