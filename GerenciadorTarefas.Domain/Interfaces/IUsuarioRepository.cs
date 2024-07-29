using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarPorId(int id);
        Task<Usuario> CadastrarUsuario(Usuario usuario);
    }
}
