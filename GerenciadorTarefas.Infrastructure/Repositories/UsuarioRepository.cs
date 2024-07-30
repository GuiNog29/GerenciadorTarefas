using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciadorTarefasDbContext _context;
        public UsuarioRepository(GerenciadorTarefasDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> BuscarPorId(int usuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            return usuario ?? throw new KeyNotFoundException($"Usuário com ID {usuarioId} não foi encontrado.");
        }

        public async Task<Usuario> CadastrarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
