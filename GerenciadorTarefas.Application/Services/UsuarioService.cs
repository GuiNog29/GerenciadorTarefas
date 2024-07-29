using AutoMapper;
using GerenciadorTarefas.Domain.Entities;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Domain.Interfaces;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> BuscarPorId(int usuarioId)
        {
            ValidarUsuarioId(usuarioId);
            var usuario = await _usuarioRepository.BuscarPorId(usuarioId);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> CadastrarUsuario(UsuarioDto usuarioDto)
        {
            ValidarUsuarioDto(usuarioDto);
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario = await _usuarioRepository.CadastrarUsuario(usuario);
            return _mapper.Map<UsuarioDto>(usuario);
        }

        private void ValidarUsuarioId(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentException("ID do usuário inválido", nameof(usuarioId));
        }

        private void ValidarUsuarioDto(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                throw new ArgumentNullException(nameof(usuarioDto));
        }
    }
}
