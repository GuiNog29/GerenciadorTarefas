﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Projeto> CadastrarProjeto(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<bool> ExcluirProjeto(int projetoId)
        {
            var projeto = await _context.Projetos.FindAsync(projetoId);
            if (projeto == null)
                throw new KeyNotFoundException($"Projeto com ID {projetoId} não foi encontrado.");

            if (projeto.Tarefas != null && projeto.Tarefas.Count > 0)
                throw new Exception($"Projeto {projeto.NomeProjeto} ainda contém tarefas não finalizadas, conclua ou exclua todas antes de excluir o projeto.");

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Projeto>> ListarProjetos()
        {
            var projetos = await _context.Projetos.ToListAsync();
            if (projetos.Count == 0) 
                throw new Exception("Não foi encontrado nenhum projeto, favor cadastrar.");

            return projetos;
        }

        public async Task<Projeto> VisualizarProjeto(int projetoId)
        {
            var projeto = await _context.Projetos.FindAsync(projetoId);
            return projeto ?? throw new KeyNotFoundException($"Projeto com ID {projetoId} não foi encontrado.");
        }
    }
}
