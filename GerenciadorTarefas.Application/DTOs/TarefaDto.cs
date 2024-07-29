﻿namespace GerenciadorTarefas.Application.DTOs
{
    public class TarefaDto
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Status { get; set; }
        public required string Prioridade { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
    }
}