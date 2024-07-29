using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCadastrado = await _usuarioService.CadastrarUsuario(usuarioDto);
                return Ok(usuarioCadastrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar cadastrar usuário: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> BuscarPorId(int usuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.BuscarPorId(usuarioId);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar buscar usuario: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
