using System.ComponentModel;

namespace GerenciadorTarefas.Domain.Enums
{
    public enum Prioridade
    {
        [Description("Baixa")]
        Baixa,
        [Description("Média")]
        Media,
        [Description("Alta")]
        Alta
    }
}
