using AutoMapper;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<TarefaDto> CadastrarTarefa(TarefaDto tarefaDto)
        {
            ValidarTarefaDto(tarefaDto);
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            tarefa = await _tarefaRepository.CadastrarTarefa(tarefa);
            return _mapper.Map<TarefaDto>(tarefa);
        }

        public async Task<TarefaDto> AtualizarTarefa(TarefaDto tarefaDto)
        {
            ValidarTarefaDto(tarefaDto);
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            var tarefaAtualizada = await _tarefaRepository.AtualizarTarefa(tarefa);
            return _mapper.Map<TarefaDto>(tarefaAtualizada);
        }
        
        public async Task<bool> ExcluirTarefa(int tarefaId)
        {
            ValidarTarefaId(tarefaId);
            return await _tarefaRepository.ExcluirTarefa(tarefaId);
        }

        public async Task<IEnumerable<TarefaDto>> ListarTarefas(int projetoId)
        {
            ValidarProjetoId(projetoId);
            var listaTarefas = await _tarefaRepository.ListarTarefas(projetoId);
            return _mapper.Map<IEnumerable<TarefaDto>>(listaTarefas);
        }

        public async Task<TarefaDto> VisualizarTarefa(int tarefaId)
        {
            ValidarTarefaId(tarefaId);
            var tarefa = await _tarefaRepository.VisualizarTarefa(tarefaId);
            return _mapper.Map<TarefaDto>(tarefa);
        }

        private void ValidarTarefaDto(TarefaDto tarefaDto)
        {
            if (tarefaDto == null)
                throw new ArgumentNullException(nameof(tarefaDto));
        }

        private void ValidarTarefaId(int tarefaId)
        {
            if (tarefaId <= 0)
                throw new ArgumentException("ID da tarefa inválido", nameof(tarefaId));
        }

        private void ValidarProjetoId(int projetoId)
        {
            if (projetoId <= 0)
                throw new ArgumentException("ID do projeto inválido", nameof(projetoId));
        }
    }
}
