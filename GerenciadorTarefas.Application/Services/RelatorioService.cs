using AutoMapper;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        public RelatorioService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RelatorioDesempenhoUsuarioDto>> GerarRelatorioDesempenhoUsuario(int usuarioId)
        {
            var relatorioDesempenhoUsuario = await _tarefaRepository.GerarRelatorioDesempenhoUsuario(usuarioId);
            return _mapper.Map<IEnumerable<RelatorioDesempenhoUsuarioDto>>(relatorioDesempenhoUsuario);
        }
    }
}
