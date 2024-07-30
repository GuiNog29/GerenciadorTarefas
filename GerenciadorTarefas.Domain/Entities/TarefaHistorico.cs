namespace GerenciadorTarefas.Domain.Entities
{
    public class TarefaHistorico
    {
        public int Id { get; set; }
        public int TarefaId { get; set; }
        public required Tarefa Tarefa { get; set; }
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }
        public required string Alteracao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
