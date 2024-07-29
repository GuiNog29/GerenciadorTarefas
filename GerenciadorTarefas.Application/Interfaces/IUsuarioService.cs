using GerenciadorTarefas.Application.DTOs;

namespace GerenciadorTarefas.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> BuscarPorId(int id);
        Task<UsuarioDto> CadastrarUsuario(UsuarioDto usuarioDto);
    }
}
