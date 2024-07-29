using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _context;
        public UsuarioRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return usuario ?? throw new KeyNotFoundException($"Usuário com ID {id} não foi encontrado.");
        }

        public async Task<Usuario> CadastrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
