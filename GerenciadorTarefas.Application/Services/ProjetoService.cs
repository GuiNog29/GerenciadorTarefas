using AutoMapper;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task<ProjetoDto> CadastrarProjeto(ProjetoDto projetoDto)
        {
            if (projetoDto == null)
                throw new ArgumentNullException(nameof(projetoDto));

            var projeto = _mapper.Map<Projeto>(projetoDto);
            projeto = await _projetoRepository.CadastrarProjeto(projeto);
            return _mapper.Map<ProjetoDto>(projeto);
        }

        public async Task<bool> ExcluirProjeto(int projetoId)
        {
            ValidarProjetoId(projetoId);
            return await _projetoRepository.ExcluirProjeto(projetoId);
        }

        public async Task<IEnumerable<ProjetoDto>> ListarProjetos()
        {
            var projetos = await _projetoRepository.ListarProjetos();
            return _mapper.Map<IEnumerable<ProjetoDto>>(projetos);
        }

        public async Task<ProjetoDto> VisualizarProjeto(int projetoId)
        {
            ValidarProjetoId(projetoId);
            var projeto = await _projetoRepository.VisualizarProjeto(projetoId);
            return _mapper.Map<ProjetoDto>(projeto);
        }

        private void ValidarProjetoId(int projetoId)
        {
            if (projetoId <= 0)
                throw new ArgumentException("ID do projeto inválido", nameof(projetoId));
        }
    }
}
