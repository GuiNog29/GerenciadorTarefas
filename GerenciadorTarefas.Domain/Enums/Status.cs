using System.ComponentModel;

namespace GerenciadorTarefas.Domain.Enums
{
    public enum Status
    {
        [Description("Pendente")]
        Pendente,
        [Description("Em andamento")]
        EmAndamento,
        [Description("Concluída")]
        Concluida
    }
}
