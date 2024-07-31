using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Domain.Enums;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;
        private readonly IUsuarioService _usuarioService;

        public RelatorioController(IRelatorioService relatorioService, IUsuarioService usuarioService)
        {
            _relatorioService = relatorioService;
            _usuarioService = usuarioService;
        }

        [HttpGet("GerarRelatorioDesempenhoUsuario")]
        public async Task<IActionResult> GerarRelatorioDesempenhoUsuario(int usuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = await _usuarioService.BuscarPorId(usuarioId);
                if (usuario == null || usuario.TipoUsuario != TipoUsuario.Gerente)
                    return Forbid("Acesso negado, apenas gerentes podem acessar os relatórios de desempenho do usuário");

                var relatorio = await _relatorioService.GerarRelatorioDesempenhoUsuario(usuarioId);
                return Ok(relatorio);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar gerar relatório de desempenho do usuário: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}
