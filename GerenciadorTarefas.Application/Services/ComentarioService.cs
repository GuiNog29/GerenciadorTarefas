using AutoMapper;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Application.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IMapper _mapper;

        public ComentarioService(IComentarioRepository comentarioRepository, IMapper mapper)
        {
            _comentarioRepository = comentarioRepository;
            _mapper = mapper;
        }

        public async Task<ComentarioDto> AdicionarComentario(ComentarioDto comentarioDto)
        {
            ValidarComentarioDto(comentarioDto);
            var comentario = _mapper.Map<Comentario>(comentarioDto);
            var comentarioCadastrado = await _comentarioRepository.AdicionarComentario(comentario);
            return _mapper.Map<ComentarioDto>(comentarioCadastrado);
        }

        public async Task<IEnumerable<ComentarioDto>> BuscarComentarios(int tarefaId)
        {
            ValidarTarefaId(tarefaId);
            var comentarios = await _comentarioRepository.BuscarComentarios(tarefaId);
            return _mapper.Map<IEnumerable<ComentarioDto>>(comentarios);
        }

        private void ValidarComentarioDto(ComentarioDto comentarioDto)
        {
            if (comentarioDto == null)
                throw new ArgumentNullException(nameof(comentarioDto));
        }

        private void ValidarTarefaId(int tarefaId)
        {
            if (tarefaId <= 0)
                throw new ArgumentException("ID da tarefa inválido", nameof(tarefaId));
        }
    }
}
