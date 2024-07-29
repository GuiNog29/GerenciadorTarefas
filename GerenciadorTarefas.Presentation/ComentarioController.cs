using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;

        public ComentarioController(IComentarioService comentarioService)
        {
            _comentarioService = comentarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarComentario(ComentarioDto comentarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var comentario = await _comentarioService.AdicionarComentario(comentarioDto);
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar adicionar um comentário: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("{tarefaId}")]
        public async Task<IActionResult> BuscarComentarios(int tarefaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var listaComentarios = await _comentarioService.BuscarComentarios(tarefaId);
                return Ok(listaComentarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar buscar os comentários: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
