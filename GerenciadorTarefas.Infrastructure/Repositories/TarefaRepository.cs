using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Infrastructure.Data;

namespace GerenciadorTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly GerenciadorTarefasDbContext _context;

        public TarefaRepository(GerenciadorTarefasDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> CadastrarTarefa(Tarefa tarefa)
        {
            var projeto = await _context.Projetos.FindAsync(tarefa.ProjetoId);

            if (projeto == null)
                throw new KeyNotFoundException($"Projeto com ID {tarefa.ProjetoId} não foi encontrado.");

            if (projeto.Tarefas != null && projeto.Tarefas.Count <= 20)
            {
                _context.Tarefas.Add(tarefa);
                await _context.SaveChangesAsync();
                return tarefa;
            }
            else
                throw new Exception($"Projeto {projeto.NomeProjeto} só pode conter até 20 tarefas");
        }

        public async Task<Tarefa> AtualizarTarefa(Tarefa tarefa)
        {
            var tarefaExistente = await _context.Tarefas.FirstOrDefaultAsync(x => x.Id == tarefa.Id);
            if (tarefaExistente == null)
                throw new KeyNotFoundException($"Tarefa com ID {tarefa.Id} não foi encontrada.");

            VerificarAlteracoesESalvarHistorico(tarefaExistente, tarefa);

            await _context.SaveChangesAsync();
            return tarefaExistente;
        }

        public async Task<bool> ExcluirTarefa(int tarefaId)
        {
            var tarefa = await _context.Tarefas.FindAsync(tarefaId);
            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com ID {tarefaId} não foi encontrada.");

            if (tarefa.Comentarios != null && tarefa.Comentarios.Count != 0)
                _context.Comentarios.RemoveRange(tarefa.Comentarios);

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefas(int projetoId)
        {
            var tarefas = await _context.Tarefas.Include(x => x.Comentarios).Where(x => x.ProjetoId == projetoId).ToListAsync();
            if (tarefas.Count == 0)
                throw new Exception($"Não foi encontrado nenhuma tarefa no projeto, favor cadastrar novas tarefas.");

            return tarefas;
        }

        public async Task<Tarefa> VisualizarTarefa(int tarefaId)
        {
            var tarefa = await _context.Tarefas.Include(x => x.Comentarios).FirstOrDefaultAsync(x => x.Id == tarefaId);
            if (tarefa == null)
                throw new KeyNotFoundException($"Tarefa com ID {tarefaId} não foi encontrada.");

            return tarefa;
        }

        private void AdicionarAlteracaoHistorico(Tarefa tarefa, string alteracao)
        {
            var historicoTarefa = new TarefaHistorico
            {
                TarefaId = tarefa.Id,
                Tarefa = tarefa,
                UsuarioId = tarefa.UsuarioId,
                Usuario = tarefa.Usuario,
                Alteracao = alteracao,
                DataAlteracao = DateTime.Now,
            };

            _context.TarefaHistoricos.Add(historicoTarefa);
        }

        private void VerificarAlteracoesESalvarHistorico(Tarefa tarefaExistente, Tarefa tarefa)
        {
            var alteracoes = new List<string>();
            if (tarefaExistente.Titulo != tarefa.Titulo)
            {
                alteracoes.Add($"Título alterado de '{tarefaExistente.Titulo}' para '{tarefa.Titulo}'");
                tarefaExistente.Titulo = tarefa.Titulo;
            }

            if (tarefaExistente.Descricao != tarefa.Descricao)
            {
                alteracoes.Add($"Descrição alterada de '{tarefaExistente.Descricao}' para '{tarefa.Descricao}'");
                tarefaExistente.Descricao = tarefa.Descricao;
            }

            if (tarefaExistente.Status != tarefa.Status)
            {
                alteracoes.Add($"Status alterado de '{tarefaExistente.Status}' para '{tarefa.Status}'");
                tarefaExistente.Status = tarefa.Status;
            }

            var prioridade = tarefaExistente.Prioridade;
            _context.Entry(tarefaExistente).CurrentValues.SetValues(tarefa);
            tarefaExistente.Prioridade = prioridade;

            foreach (var alteracao in alteracoes)
            {
                AdicionarAlteracaoHistorico(tarefaExistente, alteracao);
            }
        }

        public async Task<IEnumerable<RelatorioDesempenhoUsuario>> GerarRelatorioDesempenhoUsuario(int usuarioId)
        {
            var ultimosTrintaDias = DateTime.Now.AddDays(-30);

            var desempenhoUsuario = await _context.Tarefas
                .Where(x => x.DataVencimento >= ultimosTrintaDias && x.UsuarioId == usuarioId)
                .GroupBy(y => y.UsuarioId)
                .Select(z => new RelatorioDesempenhoUsuario
                {
                    UsuarioId = z.Key,
                    TotalTarefasConcluidas = z.Count()
                }).ToListAsync();

            return desempenhoUsuario;
        }
    }
}
