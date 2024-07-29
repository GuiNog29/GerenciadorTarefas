namespace GerenciadorTarefas.Domain.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Conteudo { get; set; }
        public DateTime Data { get; set; }
        public required int TarefaId { get; set; }
        public required Tarefa Tarefa { get; set; }
    }
}
