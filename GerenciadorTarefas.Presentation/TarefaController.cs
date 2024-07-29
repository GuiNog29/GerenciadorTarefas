﻿using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTarefa(TarefaDto tarefaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarefaCadastrada = await _tarefaService.CadastrarTarefa(tarefaDto);
                return Ok(tarefaCadastrada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar cadastrar tarefa: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("visualizarTarefa/{tarefaId}")]
        public async Task<IActionResult> VisualizarTarefa(int tarefaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarefa = await _tarefaService.VisualizarTarefa(tarefaId);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar visualizar tarefa: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTarefa(TarefaDto tarefaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var tarefaAtualizada = await _tarefaService.AtualizarTarefa(tarefaDto);
                return Ok(tarefaAtualizada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar atualizar tarefa: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpDelete("{tarefaId}")]
        public async Task<IActionResult> ExcluirTarefa(int tarefaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _tarefaService.ExcluirTarefa(tarefaId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar excluir tarefa: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }

        [HttpGet("listarTarefas/{projetoId}")]
        public async Task<IActionResult> ListarTarefas(int projetoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var listaTarefas = await _tarefaService.ListarTarefas(projetoId);
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErroDto
                {
                    Mensagem = $"Ocorreu um erro ao tentar listar tarefas: erro {ex.Message}",
                    Detalhes = ex.StackTrace
                });
            }
        }
    }
}