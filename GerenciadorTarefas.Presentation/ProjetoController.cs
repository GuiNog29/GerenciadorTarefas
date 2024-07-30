using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProjeto(ProjetoDto projetoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var projetoCadastrado = await _projetoService.CadastrarProjeto(projetoDto);
                return Ok(projetoCadastrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar cadastrar projeto: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("{projetoId}")]
        public async Task<IActionResult> VisualizarProjeto(int projetoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var projeto = await _projetoService.VisualizarProjeto(projetoId);
                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar visualizar projeto: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpDelete("{projetoId}")]
        public async Task<IActionResult> ExcluirProjeto(int projetoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _projetoService.ExcluirProjeto(projetoId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar excluir projeto: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarProjetos()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var listaProjetos = await _projetoService.ListarProjetos();
                return Ok(listaProjetos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar listar projetos: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
