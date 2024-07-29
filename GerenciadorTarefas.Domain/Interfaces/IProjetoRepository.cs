using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface IProjetoRepository
    {
        Task<Projeto> CadastrarProjeto(Projeto projeto);
        Task<Projeto> VisualizarProjeto(int projetoId);
        Task<bool> ExcluirProjeto(int projetoId);
        Task<IEnumerable<Projeto>> ListarProjetos();
    }
}
