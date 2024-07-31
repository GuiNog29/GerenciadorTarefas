using Moq;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Presentation;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Tests
{
    public class UsuarioControllerTests
    {
        private readonly UsuarioController _usuarioController;
        private readonly Mock<IUsuarioService> _mockUsuarioService;

        public UsuarioControllerTests()
        {
            _mockUsuarioService = new Mock<IUsuarioService>();
            _usuarioController = new UsuarioController(_mockUsuarioService.Object);
        }

        [Fact]
        public async Task CadastrarUsuario_ReturnsOkResult_WhenUsuarioIsCadastrado()
        {
            var usuarioDto = new UsuarioDto { Nome = "Novo Usuario", TipoUsuario = GerenciadorTarefas.Domain.Enums.TipoUsuario.Gerente };
            _mockUsuarioService.Setup(service => service.CadastrarUsuario(usuarioDto)).ReturnsAsync(usuarioDto);

            var result = await _usuarioController.CadastrarUsuario(usuarioDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(usuarioDto, okResult.Value);
        }

        [Fact]
        public async Task BuscarPorId_ReturnsOkResult_WhenUsuarioIsFound()
        {
            var usuarioId = 1;
            var usuarioDto = new UsuarioDto { Id = usuarioId, Nome = "Usuario Existente", TipoUsuario = GerenciadorTarefas.Domain.Enums.TipoUsuario.Gerente };
            _mockUsuarioService.Setup(service => service.BuscarPorId(usuarioId)).ReturnsAsync(usuarioDto);

            var result = await _usuarioController.BuscarPorId(usuarioId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(usuarioDto, okResult.Value);
        }

        [Fact]
        public async Task CadastrarUsuario_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            _usuarioController.ModelState.AddModelError("Nome", "Required");

            var usuarioDto = new UsuarioDto { Nome = "", TipoUsuario = GerenciadorTarefas.Domain.Enums.TipoUsuario.Gerente };
            var result = await _usuarioController.CadastrarUsuario(usuarioDto);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task BuscarPorId_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            _usuarioController.ModelState.AddModelError("UsuarioId", "Required");

            var result = await _usuarioController.BuscarPorId(0);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CadastrarUsuario_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            var usuarioDto = new UsuarioDto { Nome = "Novo Usuario", TipoUsuario = GerenciadorTarefas.Domain.Enums.TipoUsuario.Gerente };
            _mockUsuarioService.Setup(service => service.CadastrarUsuario(usuarioDto)).ThrowsAsync(new Exception("Erro ao cadastrar"));

            var result = await _usuarioController.CadastrarUsuario(usuarioDto);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task BuscarPorId_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            var usuarioId = 1;
            _mockUsuarioService.Setup(service => service.BuscarPorId(usuarioId)).ThrowsAsync(new Exception("Erro ao buscar"));

            var result = await _usuarioController.BuscarPorId(usuarioId);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
