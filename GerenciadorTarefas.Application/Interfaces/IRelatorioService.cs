using GerenciadorTarefas.Application.DTOs;

namespace GerenciadorTarefas.Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<IEnumerable<RelatorioDesempenhoUsuarioDto>> GerarRelatorioDesempenhoUsuario(int usuarioId);
    }
}
