using Moq;
using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Presentation;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Interfaces;

namespace GerenciadorTarefas.Tests
{
    public class ComentarioControllerTests
    {
        private readonly Mock<IComentarioService> _comentarioServiceMock;
        private readonly ComentarioController _controller;

        public ComentarioControllerTests()
        {
            _comentarioServiceMock = new Mock<IComentarioService>();
            _controller = new ComentarioController(_comentarioServiceMock.Object);
        }

        [Fact]
        public async Task AdicionarComentario_RetornaOkResult_QuandoComentarioValido()
        {
            var comentarioDto = new ComentarioDto
            {
                Id = 1,
                Conteudo = "Comentário de teste",
                Data = DateTime.Now,
                TarefaId = 1
            };
            var comentario = comentarioDto; // Supondo que o serviço retorne o mesmo DTO

            _comentarioServiceMock.Setup(service => service.AdicionarComentario(comentarioDto))
                                  .ReturnsAsync(comentario);

            var result = await _controller.AdicionarComentario(comentarioDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(comentario, okResult.Value);
        }

        [Fact]
        public async Task AdicionarComentario_RetornaStatusCode500_QuandoOcorreException()
        {
            // Arrange
            var comentarioDto = new ComentarioDto
            {
                Id = 1,
                Conteudo = "Comentário de teste",
                Data = DateTime.Now,
                TarefaId = 1
            };

            _comentarioServiceMock.Setup(service => service.AdicionarComentario(comentarioDto))
                                  .ThrowsAsync(new Exception("Test Exception"));

            var result = await _controller.AdicionarComentario(comentarioDto);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);

            var erroDto = Assert.IsType<ErroDto>(objectResult.Value);
            Assert.Equal("Ocorreu um erro ao tentar adicionar um comentário: erro Test Exception", erroDto.Mensagem);
        }

        [Fact]
        public async Task BuscarComentarios_RetornaOkResult_QuandoComentariosExistem()
        {
            int tarefaId = 1;
            var comentarios = new List<ComentarioDto>
            {
                new ComentarioDto
                {
                    Id = 1,
                    Conteudo = "Comentário 1",
                    Data = DateTime.Now,
                    TarefaId = tarefaId
                }
            };

            _comentarioServiceMock.Setup(service => service.BuscarComentarios(tarefaId))
                                  .ReturnsAsync(comentarios);

            var result = await _controller.BuscarComentarios(tarefaId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(comentarios, okResult.Value);
        }

        [Fact]
        public async Task BuscarComentarios_RetornaStatusCode500_QuandoOcorreException()
        {
            int tarefaId = 1;
            _comentarioServiceMock.Setup(service => service.BuscarComentarios(tarefaId))
                                  .ThrowsAsync(new Exception("Test Exception"));

            var result = await _controller.BuscarComentarios(tarefaId);

            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);

            var erroDto = Assert.IsType<ErroDto>(objectResult.Value);
            Assert.Equal("Ocorreu um erro ao tentar buscar os comentários: erro Test Exception", erroDto.Mensagem);
        }
    }
}
