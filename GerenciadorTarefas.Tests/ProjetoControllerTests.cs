using Moq;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Presentation;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Tests
{
    public class ProjetoControllerTests
    {
        private readonly Mock<IProjetoService> _mockProjetoService;
        private readonly ProjetoController _projetoController;

        public ProjetoControllerTests()
        {
            _mockProjetoService = new Mock<IProjetoService>();
            _projetoController = new ProjetoController(_mockProjetoService.Object);
        }

        [Fact]
        public async Task CadastrarProjeto_ReturnsOkResult_WhenProjetoIsValid()
        {
            var projetoDto = new ProjetoDto { Id = 1, NomeProjeto = "Novo Projeto" };
            _mockProjetoService.Setup(service => service.CadastrarProjeto(projetoDto)).ReturnsAsync(projetoDto);

            var result = await _projetoController.CadastrarProjeto(projetoDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProjetoDto>(okResult.Value);
            Assert.Equal(projetoDto.Id, returnValue.Id);
        }

        [Fact]
        public async Task VisualizarProjeto_ReturnsOkResult_WhenProjetoExists()
        {
            var projetoDto = new ProjetoDto { Id = 1, NomeProjeto = "Projeto Existente" };
            _mockProjetoService.Setup(service => service.VisualizarProjeto(projetoDto.Id)).ReturnsAsync(projetoDto);

            var result = await _projetoController.VisualizarProjeto(projetoDto.Id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProjetoDto>(okResult.Value);
            Assert.Equal(projetoDto.Id, returnValue.Id);
        }

        [Fact]
        public async Task ExcluirProjeto_ReturnsOkResult_WhenProjetoIsDeleted()
        {
            var projetoId = 1;
            _mockProjetoService.Setup(service => service.ExcluirProjeto(projetoId)).ReturnsAsync(true);

            var result = await _projetoController.ExcluirProjeto(projetoId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.True((bool)okResult.Value!);
        }


        [Fact]
        public async Task ListarProjetos_ReturnsOkResult_WithListOfProjetos()
        {
            var usuarioId = 1;
            var listaProjetos = new List<ProjetoDto>
            {
                new ProjetoDto { Id = 1, NomeProjeto = "Projeto 1", UsuarioId = 1 },
                new ProjetoDto { Id = 2, NomeProjeto = "Projeto 2", UsuarioId = 2 }
            };

            _mockProjetoService.Setup(service => service.ListarProjetos(usuarioId)).ReturnsAsync(listaProjetos);

            var result = await _projetoController.ListarProjetos(usuarioId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProjetoDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task CadastrarProjeto_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var projetoDto = new ProjetoDto { Id = 1, NomeProjeto = "Novo Projeto" };
            _projetoController.ModelState.AddModelError("NomeProjeto", "O campo NomeProjeto é obrigatório");

            var result = await _projetoController.CadastrarProjeto(projetoDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
