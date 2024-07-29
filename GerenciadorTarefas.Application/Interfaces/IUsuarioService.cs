using GerenciadorTarefas.Application.DTOs;

namespace GerenciadorTarefas.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> CadastrarUsuario(UsuarioDto usuarioDto);
        Task<UsuarioDto> BuscarPorId(int usuarioId);
    }
}
