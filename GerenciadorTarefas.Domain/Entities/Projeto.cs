namespace GerenciadorTarefas.Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public required string NomeProjeto { get; set; }
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}
