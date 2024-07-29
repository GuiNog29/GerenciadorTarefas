using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ProjetoDbContext _context;
        public ProjetoRepository(ProjetoDbContext context)
        {
            _context = context;
        }

        public Task<Projeto> CadastrarProjeto(Projeto projeto)
        {
            throw new NotImplementedException();
        }

        public Task<string> ExcluirProjeto(int projetoId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Projeto>> ListarProjetos()
        {
            throw new NotImplementedException();
        }

        public Task<Projeto> VisualizarProjeto(int projetoId)
        {
            throw new NotImplementedException();
        }
    }
}
