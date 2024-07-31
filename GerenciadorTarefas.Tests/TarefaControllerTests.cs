using Moq;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Presentation;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;
using GerenciadorTarefas.Domain.Entities;

namespace GerenciadorTarefas.Tests
{
    public class TarefaControllerTests
    {
        private readonly TarefaController _tarefaController;
        private readonly Mock<ITarefaService> _mockTarefaService;

        public TarefaControllerTests()
        {
            _mockTarefaService = new Mock<ITarefaService>();
            _tarefaController = new TarefaController(_mockTarefaService.Object);
        }

        [Fact]
        public async Task CadastrarTarefa_ReturnsOkResult_WhenTarefaIsCadastrada()
        {
            var tarefaDto = new TarefaDto { Titulo = "Nova Tarefa", Prioridade = Domain.Enums.Prioridade.Media };
            _mockTarefaService.Setup(service => service.CadastrarTarefa(tarefaDto)).ReturnsAsync(tarefaDto);

            var result = await _tarefaController.CadastrarTarefa(tarefaDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tarefaDto, okResult.Value);
        }

        [Fact]
        public async Task VisualizarTarefa_ReturnsOkResult_WhenTarefaIsFound()
        {
            var tarefaId = 1;
            var projetoId = 1;
            var tarefaDto = new TarefaDto { Id = tarefaId, Titulo = "Tarefa Existente", Prioridade = Domain.Enums.Prioridade.Media, ProjetoId = projetoId };
            _mockTarefaService.Setup(service => service.VisualizarTarefa(projetoId, tarefaId)).ReturnsAsync(tarefaDto);

            var result = await _tarefaController.VisualizarTarefa(projetoId, tarefaId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tarefaDto, okResult.Value);
        }

        [Fact]
        public async Task AtualizarTarefa_ReturnsOkResult_WhenTarefaIsAtualizada()
        {
            var tarefaId = 1;
            var projetoId = 1;
            var tarefaDto = new TarefaDto { Id = tarefaId, Titulo = "Tarefa Atualizada", Prioridade = Domain.Enums.Prioridade.Media, ProjetoId = projetoId };
            _mockTarefaService.Setup(service => service.AtualizarTarefa(tarefaDto)).ReturnsAsync(tarefaDto);

            var result = await _tarefaController.AtualizarTarefa(tarefaDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tarefaDto, okResult.Value);
        }

        [Fact]
        public async Task ExcluirTarefa_ReturnsOkResult_WhenTarefaIsDeleted()
        {
            var tarefaId = 1;
            var projetoId = 1;
            _mockTarefaService.Setup(service => service.ExcluirTarefa(projetoId, tarefaId)).ReturnsAsync(true);

            var result = await _tarefaController.ExcluirTarefa(projetoId, tarefaId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.True((bool?)okResult.Value);
        }

        [Fact]
        public async Task ListarTarefas_ReturnsOkResult_WithListOfTarefas()
        {
            var projetoId = 1;
            var listaTarefas = new List<TarefaDto> { new TarefaDto { Id = 1, Titulo = "Tarefa 1", Prioridade = Domain.Enums.Prioridade.Media } };
            _mockTarefaService.Setup(service => service.ListarTarefas(projetoId)).ReturnsAsync(listaTarefas);

            var result = await _tarefaController.ListarTarefas(projetoId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(listaTarefas, okResult.Value);
        }
    }
}
